using System;
using System.Windows.Input;
using ServiceStack.Text;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.AppServices.Orders;
using apcurium.MK.Booking.Mobile.Data;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Mobile.PresentationHints;
using Cirrious.MvvmCross.Plugins.PhoneCall;


namespace apcurium.MK.Booking.Mobile.ViewModels.Orders
{
	public class BottomBarViewModel: ChildViewModel
    {
		readonly IOrderWorkflowService _orderWorkflowService;
		readonly IMessageService _messageService;
		readonly ILocalization _localize;
		readonly IMvxPhoneCallTask _phone;

		public BottomBarViewModel(IOrderWorkflowService orderWorkflowService,
			IMessageService messageService,
			ILocalization localize,
			IMvxPhoneCallTask phone)
		{
			_phone = phone;
			_localize = localize;
			_messageService = messageService;
			_orderWorkflowService = orderWorkflowService;

			this.Observe(_orderWorkflowService.GetAndObserveAddressSelectionMode(),
				m => EstimateSelected = m == AddressSelectionMode.DropoffSelection);
		}

		private bool _estimateSelected;
		public bool EstimateSelected
		{
			get
			{
				return _estimateSelected;
			}
			set
			{
				if(value != _estimateSelected)
				{
					_estimateSelected = value;
					RaisePropertyChanged();
				}
			}
		}

		public ICommand ChangeAddressSelectionMode
		{
			get
			{
				return this.GetCommand(() => {
					_orderWorkflowService.ToggleBetweenPickupAndDestinationSelectionMode();
				});
			}
		}

		public ICommand SetPickupDateAndReviewOrder
		{
			get
			{
				return this.GetCommand<DateTime?>(async date =>
				{
					await _orderWorkflowService.SetPickupDate(date);
					try
					{
						await _orderWorkflowService.ValidatePickupDestinationAndTime();
						ChangePresentation(new HomeViewModelPresentationHint(HomeViewModelState.Review));
					}
					catch (OrderValidationException e)
					{
						switch (e.Error)
						{
							case OrderValidationError.PickupAddressRequired:
								_messageService.ShowMessage(_localize["InvalidBookinInfoTitle"], _localize["InvalidBookinInfo"]);
								break;
							case OrderValidationError.DestinationAddressRequired:
								_messageService.ShowMessage(_localize["InvalidBookinInfoTitle"], _localize["InvalidBookinInfoWhenDestinationIsRequired"]);
								break;
							case OrderValidationError.InvalidPickupDate:
								_messageService.ShowMessage(_localize["InvalidBookinInfoTitle"], _localize["BookViewInvalidDate"]);
								break;
							default:
								Logger.LogError(e);
								break;
						}
					}
				});
			}
		}

		public ICommand ConfirmOrder
		{
			get
			{
				return this.GetCommand(async () =>
				{
					try
					{
						var result = await _orderWorkflowService.ConfirmOrder();
						ChangePresentation(new HomeViewModelPresentationHint(HomeViewModelState.Initial));
						ShowViewModel<BookingStatusViewModel>(new
						{
							order = result.Item1.ToJson(),
							orderStatus = result.Item2.ToJson()
						});

					}
					catch(OrderCreationException e)
					{
						Logger.LogError(e);

						var settings = this.Services().Settings;
						var callIsEnabled = !settings.HideCallDispatchButton;
						var title = _localize["ErrorCreatingOrderTitle"];

						if (callIsEnabled)
						{
							_messageService.ShowMessage(title,
								e.Message,
								"Call",
								() => _phone.MakePhoneCall (settings.ApplicationName, settings.DefaultPhoneNumber),
								"Cancel",
								delegate { });
						}
						else
						{
							_messageService.ShowMessage(title, e.Message);
						}
					}
					catch(Exception e)
					{
						Logger.LogError(e);
					}


				});
			}
		}

        public ICommand BookLater
        {
            get
            {
				return this.GetCommand(() => {
                    ChangePresentation(new HomeViewModelPresentationHint(HomeViewModelState.PickDate));
                });
            }
        }

		public ICommand Edit
		{
			get
			{
				return this.GetCommand(() => {
					ChangePresentation(new HomeViewModelPresentationHint(HomeViewModelState.Edit));
				});
			}
		}

		private ICommand _save;
		public ICommand Save
		{
			get { return _save; }
			set
			{
				if (value != _save)
				{
					_save = value;
					RaisePropertyChanged();
				}
			}
		}	

		public ICommand CancelReview
        {
            get
			{
				return this.GetCommand(() => {
					ChangePresentation(new HomeViewModelPresentationHint(HomeViewModelState.Initial));
				});
			}
        }

		private ICommand _cancelEdit;
		public ICommand CancelEdit
		{
			get { return _cancelEdit; }
			set
			{
				if (value != _cancelEdit)
				{
					_cancelEdit = value;
					RaisePropertyChanged();
				}
			}
		}

    }
}

