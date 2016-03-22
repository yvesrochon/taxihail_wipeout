﻿#region

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Maps;
using apcurium.MK.Booking.Maps.Geo;
using apcurium.MK.Booking.ReadModel.Query.Contract;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Diagnostic;
using Infrastructure.Messaging;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Common.Extensions;
using CustomerPortal.Client;
using Tariff = apcurium.MK.Common.Entity.Tariff;

#endregion

namespace apcurium.MK.Booking.Api.Services.Maps
{
    public class DirectionsService : BaseApiService
    {
        private readonly IDirections _client;
        private readonly IServerSettings _serverSettings;
        private readonly IOrderDao _orderDao;
        private readonly VehicleService _vehicleService;
        private readonly ILogger _logger;
        private readonly ICommandBus _commandBus;
        private readonly ITaxiHailNetworkServiceClient _networkServiceClient;

        public DirectionsService(IDirections client, IServerSettings serverSettings, IOrderDao orderDao, VehicleService vehicleService, ILogger logger, ICommandBus commandBus, ITaxiHailNetworkServiceClient networkServiceClient)
        {
            _client = client;
            _serverSettings = serverSettings;
            _orderDao = orderDao;
            _vehicleService = vehicleService;
            _logger = logger;
            _commandBus = commandBus;
            _networkServiceClient = networkServiceClient;
        }

        public async Task<DirectionInfo> Get(DirectionsRequest request)
        {
            if (!request.OriginLat.HasValue || !request.OriginLng.HasValue)
            {
                throw GenerateException(HttpStatusCode.BadRequest, "MissingPosition", "An original longitude and latitude is required");
            }

            var marketTariff = await GetMarketTariff(request.OriginLat.Value, request.OriginLng.Value);

            var result = _client.GetDirection(request.OriginLat, request.OriginLng, request.DestinationLat,
                request.DestinationLng, request.VehicleTypeId, request.Date,false, marketTariff);

            var directionInfo = new DirectionInfo
            {
                Distance = result.Distance,
                FormattedDistance = result.FormattedDistance,
                Price = result.Price,
                FormattedPrice = result.FormattedPrice,
                TripDurationInSeconds = (int?)result.Duration
            };

            if (!_serverSettings.ServerData.ShowEta)
            {
                return directionInfo;
            }

            try
            {
                // Get available vehicles                
                var availableVehicles = await _vehicleService.Post(new AvailableVehicles
                {
                    Latitude = request.OriginLat.Value,
                    Longitude = request.OriginLng.Value,
                    VehicleTypeId = null
                });

                // Get nearest available vehicle
                var nearestAvailableVehicle = GetNearestAvailableVehicle(
                    request.OriginLat.Value,
                    request.OriginLng.Value,
                    availableVehicles.ToArray());

                if (nearestAvailableVehicle != null)
                {
                    // Get eta
                    var etaDirectionInfo =
                        _client.GetEta(nearestAvailableVehicle.Latitude,
                            nearestAvailableVehicle.Longitude,
                            request.OriginLat.Value,
                            request.OriginLng.Value);

                    directionInfo.EtaFormattedDistance = etaDirectionInfo.FormattedDistance;
                    directionInfo.EtaDuration = (int?)etaDirectionInfo.Duration;
                }
            }
            catch (Exception ex)
            {
                _logger.LogMessage("Direction Service: Error trying to get ETA: " + ex.Message, ex);
            }

            return directionInfo;
        }

        private async Task<Tariff> GetMarketTariff(double latitude, double longitude)
        {
            var marketSettings = await _networkServiceClient.GetCompanyMarketSettings(latitude, longitude);

            if (!marketSettings.Market.HasValueTrimmed() || !marketSettings.EnableAppFareEstimates)
            {
                return null;
            }

            return marketSettings.MarketTariff;
        }

        public Direction Get(AssignedEtaRequest request)
        {
            var order = _orderDao.FindById(request.OrderId);
            var eta = _client.GetEta(request.VehicleLat, request.VehicleLng, order.PickupAddress.Latitude, order.PickupAddress.Longitude);

            var orderStatus = _orderDao.FindOrderStatusById(request.OrderId);

            if (orderStatus != null && !orderStatus.OriginalEta.HasValue && eta.Duration.HasValue)
            {
                _commandBus.Send(new LogOriginalEta
                {
                    OrderId = request.OrderId,
                    OriginalEta = eta.Duration.Value
                });
            }

            return eta;
        }

        private AvailableVehicle GetNearestAvailableVehicle(double originLat, double originLng, AvailableVehicle[] availableVehicles)
        {
            if (availableVehicles == null || !availableVehicles.Any())
            {
                return null;
            }

            return availableVehicles
                .OrderBy(car => Position.CalculateDistance(car.Latitude, car.Longitude, originLat, originLng))
                .ToArray().First();
        }
    }
}