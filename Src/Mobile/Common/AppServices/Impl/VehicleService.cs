using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using apcurium.MK.Booking.Api.Client;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common.Entity;
using System.Collections.Generic;
using apcurium.MK.Booking.Maps.Geo;
using apcurium.MK.Booking.Maps;
using apcurium.MK.Common.Configuration;
using System.Reactive.Threading.Tasks;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Common.Enumeration;
using apcurium.MK.Common.Extensions;

namespace apcurium.MK.Booking.Mobile.AppServices.Impl
{
	public class VehicleService : BaseService, IVehicleService
    {
		readonly IConnectableObservable<AvailableVehicle[]> _availableVehiclesObservable;
        readonly IObservable<AvailableVehicle[]> _availableVehiclesWhenTypeChangesObservable;
		readonly IObservable<Direction> _etaObservable;
	    private readonly IObservable<bool> _isUsingGeoServices; 
		readonly ISubject<IObservable<long>> _timerSubject = new BehaviorSubject<IObservable<long>>(Observable.Never<long>());

		readonly IDirections _directions;
		readonly IAppSettings _settings;

	    private bool _isStarted;

		public VehicleService(IOrderWorkflowService orderWorkflowService,
			IDirections directions,
			IAppSettings settings)
		{
			_directions = directions;
			_settings = settings;

			// having publish and connect fixes the problem that caused the code to be executed 2 times
			// because there was 2 subscriptions
            _availableVehiclesObservable = _timerSubject
                .Switch()
                .CombineLatest(orderWorkflowService.GetAndObservePickupAddress(), (_, address) => address)
                .Where(x => x.HasValidCoordinate())
                .SelectMany(async x => {
                    var vehicleTypeId = await orderWorkflowService.GetAndObserveVehicleType().Take(1).ToTask();
                    return await CheckForAvailableVehicles(x, vehicleTypeId);
                })
				.Publish();
			_availableVehiclesObservable.Connect ();

            _availableVehiclesWhenTypeChangesObservable = orderWorkflowService.GetAndObserveVehicleType()
                .SelectMany(async vehicleTypeId => 
                    { 
                        var address = await orderWorkflowService.GetAndObservePickupAddress().Take(1).ToTask();
                        return new { vehicleTypeId, address };
                    })
                .Where(x => x.address.HasValidCoordinate())
                .SelectMany(x => CheckForAvailableVehicles(x.address, x.vehicleTypeId));

		    _isUsingGeoServices = orderWorkflowService.GetAndObserveHashedMarket()
                .Select(item => !item.HasValue()
                    ? _settings.Data.LocalAvailableVehiclesMode == LocalAvailableVehiclesModes.Geo
                    : _settings.Data.ExternalAvailableVehiclesMode == ExternalAvailableVehiclesModes.Geo
                );

            _etaObservable = _availableVehiclesObservable
				.Where (_ => _settings.Data.ShowEta)
				.CombineLatest(
                    _isUsingGeoServices,
                    orderWorkflowService.GetAndObservePickupAddress (), 
                    (vehicles, isUsingGeoServices, address) => new { address, isUsingGeoServices, vehicles } 
                )
				.Select (x => new { x.address, x.isUsingGeoServices, vehicle =  GetNearestVehicle(x.isUsingGeoServices, x.address, x.vehicles) })
				.DistinctUntilChanged(x =>
				{
				    if (x.isUsingGeoServices && x.vehicle != null)
				    {
				        return x.vehicle.Eta ?? double.MaxValue;
				    }

				    return x.vehicle == null
				        ? double.MaxValue
				        : Position.CalculateDistance(x.vehicle.Latitude, x.vehicle.Longitude, x.address.Latitude, x.address.Longitude);
				})
				.SelectMany(x => CheckForEta(x.isUsingGeoServices, x.address, x.vehicle));
		}

		public void Start()
		{   
			if(_isStarted)
			{
				return;
			}

			_isStarted = true;

		    var refreshRate = _settings.Data.AvailableVehicleRefreshRate > 0
		        ? _settings.Data.AvailableVehicleRefreshRate
		        : 1;

            _timerSubject.OnNext(Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(refreshRate)));
		}

		private async Task<AvailableVehicle[]> CheckForAvailableVehicles(Address address, int? vehicleTypeId)
		{
			try
			{
				return await UseServiceClientAsync<IVehicleClient, AvailableVehicle[]>(service => 
					service.GetAvailableVehiclesAsync(address.Latitude, address.Longitude, vehicleTypeId))
					.ConfigureAwait(false);
			}
			catch (Exception e)
			{
				Logger.LogError(e);
				return new AvailableVehicle[0];
			}
		}

		public AvailableVehicle GetNearestVehicle(bool isUsingGeoService, Address pickup, AvailableVehicle[] cars)
		{
			if (cars == null || !cars.Any ())
            {
				return null;
			}

			return OrderVehiclesByDistanceIfNeeded (isUsingGeoService, pickup, cars).First();
		}

		public MapBounds GetBoundsForNearestVehicles(bool isUsingGeoServices, Address pickup, IEnumerable<AvailableVehicle> cars)
		{
			if (cars == null || !cars.Any() || !_settings.Data.ZoomOnNearbyVehicles) 
			{
				return null;
			}

			var radius = _settings.Data.ZoomOnNearbyVehiclesRadius;
			var vehicleCount = _settings.Data.ZoomOnNearbyVehiclesCount;

			var centerLatitude = pickup.Latitude;
			var centerLongitude = pickup.Longitude;

			var vehicles = OrderVehiclesByDistanceIfNeeded (isUsingGeoServices, pickup, cars)
				.Where (car => Position.CalculateDistance (car.Latitude, car.Longitude, centerLatitude, centerLongitude) <= radius)
				.Take (vehicleCount)
				.ToArray();

			if (!vehicles.Any())
			{
				return null;
			}

			var distanceFromLastVehicle = Position.CalculateDistance (vehicles.Last ().Latitude, vehicles.Last ().Longitude, centerLatitude, centerLongitude); 

			var maximumBounds = MapBounds.GetBoundsFromCenterAndRadius(centerLatitude, centerLongitude, distanceFromLastVehicle, distanceFromLastVehicle);

			return maximumBounds;
		}

		private IEnumerable<AvailableVehicle> OrderVehiclesByDistanceIfNeeded(bool isUsingCmtGeo, Address pickup, IEnumerable<AvailableVehicle> cars)
		{
		    return isUsingCmtGeo
                // Ensure that the cars are ordered correctly.
                ? cars.OrderBy(car => car.Eta.HasValue ? 0 : 1).ThenBy(car => car.Eta).ThenBy(car  => car.VehicleNumber)
                : cars.OrderBy (car => Position.CalculateDistance (car.Latitude, car.Longitude, pickup.Latitude, pickup.Longitude));
		}

	    private async Task<Direction> CheckForEta(bool isUsingCmtGeo, Address pickup, AvailableVehicle vehicleLocation)
		{
			if(vehicleLocation == null)
			{
                return new Direction();
			}

		    var etaBetweenCoordinates = await GetEtaBetweenCoordinates(vehicleLocation.Latitude, vehicleLocation.Longitude, pickup.Latitude, pickup.Longitude);

		    if (isUsingCmtGeo)
		    {
                // Needs value in minutes not in seconds.
                etaBetweenCoordinates.Duration = vehicleLocation.Eta / 60;
		    }

		    return etaBetweenCoordinates;
		}

		
		public async Task<GeoDataEta> GetVehiclePositionInfoFromGeo(double fromLat, double fromLng, string vehicleRegistration, Guid orderId)
	    {
            var etaFromGeo = await UseServiceClientAsync<IVehicleClient, EtaForPickupResponse>(service => service.GetEtaFromGeo(fromLat, fromLng, vehicleRegistration, orderId));

		    return new GeoDataEta
		    {
		        Eta = etaFromGeo.Eta / 60,
                Latitude = etaFromGeo.Latitude,
                Longitude = etaFromGeo.Longitude
        };
	    }

		public Task<Direction> GetEtaBetweenCoordinates(double fromLat, double fromLng, double toLat, double toLng)
		{
			return _directions.GetDirectionAsync(fromLat, fromLng, toLat, toLng, null, null, true);  
		}

	    public async Task<bool> SendMessageToDriver(string message, string vehicleNumber)
	    {
            try
            {
                await UseServiceClientAsync<IVehicleClient>(service => service.SendMessageToDriver(message, vehicleNumber))
                    .ConfigureAwait(false);

                return true;
            }
            catch (Exception e)
            {
                Logger.LogMessage("Error when sending message to driver");
                Logger.LogError(e);
                return false;
            }
	    }

		public void Stop ()
		{   
			if(_isStarted)
			{
				_timerSubject.OnNext(Observable.Never<long>());
				_isStarted = false;
			}
		}

		public IObservable<AvailableVehicle[]> GetAndObserveAvailableVehicles()
		{
            return _availableVehiclesObservable.Merge (_availableVehiclesWhenTypeChangesObservable);
		}

        public IObservable<AvailableVehicle[]> GetAndObserveAvailableVehiclesWhenVehicleTypeChanges()
        {
            return _availableVehiclesWhenTypeChangesObservable;
        }

		public IObservable<Direction> GetAndObserveEta()
		{
			return _etaObservable;
		}
    }

    public class GeoDataEta
    {
        public long? Eta { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}