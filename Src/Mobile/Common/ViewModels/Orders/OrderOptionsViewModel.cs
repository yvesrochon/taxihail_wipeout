using System;
using System.Windows.Input;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Data;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using apcurium.MK.Booking.Api.Contract.Resources;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Booking.Maps;
using apcurium.MK.Common.Enumeration;

namespace apcurium.MK.Booking.Mobile.ViewModels.Orders
{
	public class OrderOptionsViewModel : BaseViewModel
	{
		private readonly IOrderWorkflowService _orderWorkflowService;
		private readonly IAccountService _accountService;
		private readonly IVehicleService _vehicleService;

		private bool _pickupInputDisabled;
		private bool _destinationInputDisabled;
		private bool _vehicleTypeInputDisabled;

        private string _hashedMarket;

		public OrderOptionsViewModel(IOrderWorkflowService orderWorkflowService, IAccountService accountService, IVehicleService vehicleService)
		{
			_orderWorkflowService = orderWorkflowService;
			_accountService = accountService;
			_vehicleService = vehicleService;

			Observe (_orderWorkflowService.GetAndObserveIsDestinationModeOpened (),
				isDestinationModeOpened => {
					IsDestinationModeOpened = isDestinationModeOpened;
					OnDestinationModeOpened ();
				});
			Observe (_orderWorkflowService.GetAndObservePickupAddress (), address => PickupAddress = address);
			Observe (_orderWorkflowService.GetAndObserveDestinationAddress (), address => DestinationAddress = address);
			Observe (_orderWorkflowService.GetAndObserveAddressSelectionMode (), selectionMode => AddressSelectionMode = selectionMode);
			Observe (_orderWorkflowService.GetAndObserveEstimatedFare (), fare => EstimatedFare = fare);
			Observe (_orderWorkflowService.GetAndObserveLoadingAddress (), loading => IsLoadingAddress = loading);
			Observe (_orderWorkflowService.GetAndObserveVehicleType (), vehicleType => VehicleTypeId = vehicleType);
            Observe (_orderWorkflowService.GetAndObserveHashedMarket(), MarketChanged);
            Observe (_orderWorkflowService.GetAndObserveMarketVehicleTypes(), marketVehicleTypes => VehicleTypesChanged(marketVehicleTypes));
			Observe (_vehicleService.GetAndObserveEta (), eta => Eta = eta);
		}

		public override void Start()
		{
			base.Start();

			Observe(ObserveHomeViewModelState(), UpdateHomeViewState);
		}

		private IObservable<HomeViewModelState> ObserveHomeViewModelState()
		{
			return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
					h => Parent.PropertyChanged += h,
					h => Parent.PropertyChanged -= h
				)
				.Where(args => args.EventArgs.PropertyName.Equals("CurrentViewState"))
				.Select(_ => ((HomeViewModel) Parent).CurrentViewState)
				.DistinctUntilChanged();
		}


		public void Init()
		{
			ShowDestination = false;

			StartAsync().FireAndForget();
		}

		public void UpdateHomeViewState(HomeViewModelState state)
		{
			switch (state)
			{
				case HomeViewModelState.Review:
					PickupInputDisabled = true;
					DestinationInputDisabled = true;
					VehicleTypeInputDisabled = true;
					break;
				case HomeViewModelState.PickDate:
					PickupInputDisabled  = true;
					DestinationInputDisabled = true;
					VehicleTypeInputDisabled = true;
					break;
				case HomeViewModelState.Initial:
					PickupInputDisabled = false;
					DestinationInputDisabled = false;
					VehicleTypeInputDisabled = false;
					break;
			}
		}

	    public async Task StartAsync()
	    {
	        await SetLocalMarketVehicleTypes();
	    }

	    private void MarketChanged(string hashedMarket)
	    {
	        _hashedMarket = hashedMarket;
	    }

	    private async Task VehicleTypesChanged(List<VehicleType> marketVehicleTypes)
	    {
	        if (_hashedMarket.HasValue())
	        {
                VehicleTypes = marketVehicleTypes;
	        }
	        else
	        {
	            await SetLocalMarketVehicleTypes();
	        }
	        
            RaisePropertyChanged(() => ShowVehicleSelection);
	    }

	    private async Task SetLocalMarketVehicleTypes()
	    {
            var list = await _accountService.GetVehiclesList();

            if (list.None())
            {
                await SetDefaultVehicleType();
            }
            else
            {
                VehicleTypes = list;
            }
	    }

	    async Task SetDefaultVehicleType()
		{
			var data = await _accountService.GetReferenceData ();
			var defaultVehicleType = data.VehiclesList.FirstOrDefault (x => x.IsDefault??false);
			var defaultId = defaultVehicleType != null
                ? defaultVehicleType.Id??0
                : 0;

			VehicleTypes = new List<VehicleType>
            {
				new VehicleType
                {
					LogoName = "taxi",
					Name = "TAXI",
					ReferenceDataVehicleId = defaultId
				}
			};

			VehicleTypeId = defaultId;
		}

		public bool IsDestinationModeOpened { get; set; }

		private int? _vehicleTypeId;
		public int? VehicleTypeId
		{
			get { return _vehicleTypeId; }
			set
			{
				_vehicleTypeId = value;
				RaisePropertyChanged();
				RaisePropertyChanged(() => SelectedVehicleType);
			}
		}

		private IEnumerable<VehicleType> _vehicleTypes = new List<VehicleType>();
		public IEnumerable<VehicleType> VehicleTypes
		{
			get
			{
				return _vehicleTypes;
			}
			set
			{
				_vehicleTypes = value ?? new List<VehicleType>();

				RaisePropertyChanged ();
				RaisePropertyChanged (() => ShowVehicleSelection);
				RaisePropertyChanged (() => SelectedVehicleType);
				RaisePropertyChanged (() => VehicleAndEstimateBoxIsVisible);
			}
		}
			
		public VehicleType SelectedVehicleType
		{
			get
            { 
				VehicleType type = null;
				if (VehicleTypeId.HasValue)
                {
					type = VehicleTypes.FirstOrDefault (x => x.ReferenceDataVehicleId == VehicleTypeId); 
				}

				if (type == null)
                {
					type = VehicleTypes.FirstOrDefault (); 
				}
				return type;
			}
		} 

		private Address _pickupAddress;
		public Address PickupAddress
		{
			get { return _pickupAddress; }
			set
			{
				if (value != _pickupAddress)
				{
					_pickupAddress = value;
					RaisePropertyChanged();
				}
			}
		}

		private Address _destinationAddress;
		public Address DestinationAddress
		{
			get { return _destinationAddress; }
			set
			{
				if (value != _destinationAddress)
				{
					_destinationAddress = value;
					RaisePropertyChanged();
				}
			}
		}

		private AddressSelectionMode _addressSelectionMode;
		public AddressSelectionMode AddressSelectionMode
		{
			get { return _addressSelectionMode; }
			set 
			{ 
				if (value != _addressSelectionMode)
				{
					_addressSelectionMode = value;
					RaisePropertyChanged();
				}
			} 
		}

		private bool _isLoadingAddress;
		public bool IsLoadingAddress
		{
			get
			{ 
				return _isLoadingAddress;
			}
			private set
			{
				if (_isLoadingAddress != value)
				{
					_isLoadingAddress = value;
					RaisePropertyChanged();
				}
			}
		}

		private bool _showDestination;
		public bool ShowDestination
		{
			get
			{ 
				return _showDestination;
			}
			private set
			{
				_showDestination = value;
				RaisePropertyChanged();
				RaisePropertyChanged(() => VehicleAndEstimateBoxIsVisible);
				RaisePropertyChanged(() => ShowEstimate);
				RaisePropertyChanged(() => ShowEta);
			}
		}

		private string _estimatedFare;
		public string EstimatedFare
		{
			get { return _estimatedFare; }
			set
			{
				if (value != _estimatedFare)
				{
					_estimatedFare = value;
					RaisePropertyChanged();
				}
			}
		}

		private Direction _eta;
		public Direction Eta
		{
			get{ return _eta; }
			set
			{ 
				_eta = value;
				RaisePropertyChanged ();
				RaisePropertyChanged(() => ShowEta);
				RaisePropertyChanged(() => VehicleAndEstimateBoxIsVisible);
				RaisePropertyChanged(() => FormattedEta);
			}
		}

		public string FormattedEta
		{
			get
			{
                if (Eta == null || (Eta != null && !Eta.IsValidEta()))
			    {
					return this.Services ().Localize ["EtaNoTaxiAvailable"];;
			    }

			    if (Eta.Duration > 30) 
			    {
			        return this.Services ().Localize ["EtaNotAvailable"];
			    }

                var durationUnit = Eta.Duration <= 1 ? this.Services().Localize["EtaDurationUnit"] : this.Services().Localize["EtaDurationUnitPlural"];

                return Eta.Duration == 0
                    ? this.Services().Localize["EtaLessThanAMinute"]
                    : string.Format(this.Services().Localize["Eta"], Eta.Duration, durationUnit);
			}
		}

		public bool VehicleAndEstimateBoxIsVisible
		{
		    get
		    {
                return ShowVehicleSelection || ShowEstimate;
		    }
		}

		public bool ShowEta
		{
			get
			{
				return Settings.ShowEta && FormattedEta.HasValue() && !ShowEstimate;
			}
		}

		public bool ShowEstimate
		{
            get { return ShowDestination && Settings.ShowEstimate; }
		}

		public bool ShowVehicleSelection
		{
			get { return (VehicleTypes.Count() > 1) && Settings.VehicleTypeSelectionEnabled; }
		}
			
        public ICommand SetAddress
        {
            get
            {
				return this.GetCommand<Address>(async address => {
					await _orderWorkflowService.SetAddress(address);
                });
            }
        }

		public ICommand SetVehicleType
		{
			get
			{
				return this.GetCommand<VehicleType>(vehicleType => {
					_orderWorkflowService.SetVehicleType(vehicleType.ReferenceDataVehicleId);
				});
			}
		}

		public ICommand ShowPickUpSearchAddress
		{
			get
			{
				return this.GetCommand(() =>
				{
				    if (AddressSelectionMode == AddressSelectionMode.DropoffSelection)
				    {
				        _orderWorkflowService.ToggleBetweenPickupAndDestinationSelectionMode();
				    }
					((HomeViewModel)Parent).CurrentViewState = HomeViewModelState.AddressSearch;
				});
			}
		}

        public ICommand ShowDestinationSearchAddress
        {
            get
            {
                return this.GetCommand(() =>
                {
                    if (AddressSelectionMode == AddressSelectionMode.PickupSelection)
                    {
                        _orderWorkflowService.ToggleBetweenPickupAndDestinationSelectionMode();
                    }

					((HomeViewModel)Parent).CurrentViewState = HomeViewModelState.AddressSearch;
                });
            }
        }

		public bool PickupInputDisabled
		{
			get { return _pickupInputDisabled; }
			set
			{
				_pickupInputDisabled = value;
				RaisePropertyChanged();
			}
		}

		public bool DestinationInputDisabled
		{
			get { return _destinationInputDisabled; }
			set
			{
				_destinationInputDisabled = value;
				RaisePropertyChanged();
			}
		}

		public bool VehicleTypeInputDisabled
		{
			get { return _vehicleTypeInputDisabled; }
			set
			{
				_vehicleTypeInputDisabled = value; 
				RaisePropertyChanged();
			}
		}

		private void OnDestinationModeOpened()
		{
			if (AddressSelectionMode == AddressSelectionMode.None
				&& !ShowDestination
				&& !IsDestinationModeOpened)
			{
				// First launch
				return;
			}

			ShowDestination = !ShowDestination;

            if (!ShowDestination)
            {
                _orderWorkflowService.ClearDestinationAddress();

				if (AddressSelectionMode == AddressSelectionMode.DropoffSelection)
				{
					_orderWorkflowService.ToggleBetweenPickupAndDestinationSelectionMode();
				}
            }
		}
	}
}

