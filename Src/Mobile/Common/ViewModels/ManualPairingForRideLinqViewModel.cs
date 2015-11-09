using System;
using System.Windows.Input;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Booking.Mobile.Framework.Extensions;
using apcurium.MK.Common.Entity;
using ServiceStack.ServiceClient.Web;
using System.Net;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class ManualPairingForRideLinqViewModel: PageViewModel, ISubViewModel<OrderManualRideLinqDetail>
    {
        private readonly IBookingService _bookingService;
        private readonly IOrderWorkflowService _orderWorkflowService;
        private string _pairingCodeLeft;
        private string _pairingCodeRight;

        public ManualPairingForRideLinqViewModel(IBookingService bookingService, IOrderWorkflowService orderWorkflowService)
        {
            _bookingService = bookingService;
            _orderWorkflowService = orderWorkflowService;
        }

        public string PairingCodeLeft
        {
            get { return _pairingCodeLeft; }
            set
            {
                if (_pairingCodeLeft != value)
                {
                    _pairingCodeLeft = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string PairingCodeRight
        {
            get { return _pairingCodeRight; }
            set
            {
                if (_pairingCodeRight != value)
                {
                    _pairingCodeRight = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand PairWithRideLinq
        {
            get
            {
                return this.GetCommand(async () =>
                {
                    var localize = this.Services().Localize;

                    if (!PairingCodeLeft.HasValue() || !PairingCodeRight.HasValue())
                    {
                        await this.Services().Message.ShowMessage(localize["ManualPairingForRideLinQ_InvalidCode_Title"], localize["ManualPairingForRideLinQ_InvalidCode_Message"]);
                        return;
                    }

                    try
                    {
                        using (this.Services().Message.ShowProgress())
                        {
                            var isCreditCardDeactivated = await _orderWorkflowService.ValidateIsCardDeactivated();
                            if (isCreditCardDeactivated)
                            {
                                 this.Services().Message.ShowMessage(localize["ErrorCreatingOrderTitle"], localize["ManualRideLinqCreditCardDisabled"]).FireAndForget();
                                 return;
                            }

                            // For the RideLinQ "street pick" feature, we need to use the user and not the pin position
                            await _orderWorkflowService.SetAddressToUserLocation();

                            var pickupAddress = await _orderWorkflowService.GetCurrentAddress();
                            var pairingCode = string.Concat(PairingCodeLeft, PairingCodeRight);
                            var orderManualRideLinqDetail = await _bookingService.PairWithManualRideLinq(pairingCode, pickupAddress);

							this.ReturnResult(orderManualRideLinqDetail);
                        }
                    }
                    catch (WebServiceException ex)
                    {
                        Logger.LogError(ex);
                        this.Services().Message.ShowMessage(localize["ManualPairingForRideLinQ_Error_Title"], localize["ManualPairingForRideLinQ_Error_Message"]).FireAndForget();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);

						int tripInfoHttpStatusCode = (int)HttpStatusCode.BadRequest;
						string errorCode = null;

						if (ex.Data != null && ex.Data.Contains("TripInfoHttpStatusCode") && ex.Data.Contains("ErrorCode"))
						{
							tripInfoHttpStatusCode = (int)ex.Data["TripInfoHttpStatusCode"];
							errorCode = (string)ex.Data["ErrorCode"];
						}

						if (tripInfoHttpStatusCode == (int)HttpStatusCode.BadRequest)
						{
							switch (errorCode)
							{
								case "104":
									this.Services().Message.ShowMessage(localize["PairingProcessingErrorTitle"], localize["CreditCardDeclinedOnPreauthorizationErrorText"]).FireAndForget();
									break;

								case "110":
									this.Services().Message.ShowMessage(localize["PairingProcessingErrorTitle"], localize["CreditCardUnanbleToPreathorizeErrorText"]).FireAndForget();
									break;

								case "103":
								default:
									this.Services().Message.ShowMessage(localize["PairingProcessingErrorTitle"], localize["TripUnableToPairErrorText"]).FireAndForget();
									break;
							}
						}
                    } 
                });
            }
        }
    }
}