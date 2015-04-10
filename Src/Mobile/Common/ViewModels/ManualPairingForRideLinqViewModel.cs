using System;
using System.ComponentModel;
using System.Windows.Input;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Common.Entity;
using ServiceStack.Text;
using System.Reactive;
using System.Reactive.Linq;
using apcurium.MK.Booking.Mobile.Framework.Extensions;
using ServiceStack.ServiceClient.Web;
using Observable = System.Reactive.Linq.Observable;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class ManualPairingForRideLinqViewModel: PageViewModel
    {
        private readonly IBookingService _bookingService;
        private string _pairingCode;
        private string _pairingCodeLeft;
        private string _pairingCodeRight;

        public ManualPairingForRideLinqViewModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public string PairingCodeLeft
        {
            get { return _pairingCodeLeft; }
            set
            {
                _pairingCodeLeft = value;
                RaisePropertyChanged();
            }
        }

        public string PairingCodeRight
        {
            get { return _pairingCodeRight; }
            set
            {
                _pairingCodeRight = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PairWithRideLinq
        {
            get
            {
                return this.GetCommand(async () =>
                {
                    if (!PairingCodeLeft.HasValue() || !PairingCodeRight.HasValue())
                    {
                        return;
                    }

                    var localize = this.Services().Localize;

                    try
                    {
                        using (this.Services().Message.ShowProgress())
                        {
                            var orderManualRideLinqDetail = await _bookingService.ManualRideLinqPair(string.Concat(PairingCodeLeft,PairingCodeRight));

                            ShowViewModelAndClearHistory<ManualRideLinqStatusViewModel>(new
                            {
                                orderManualRideLinqDetail = orderManualRideLinqDetail.SerializeToString()
                            });
                        }
                    }
                    catch (WebServiceException)
                    {
                        this.Services().Message.ShowMessage(localize["ManualPairingForRideLinQ_Error_Title"], localize["ManualPairingForRideLinQ_Error_Message"]).HandleErrors();
                    }
                    catch (Exception)
                    {
                        this.Services().Message.ShowMessage(localize["ManualPairingForRideLinQ_InvalidCode_Title"], localize["ManualPairingForRideLinQ_InvalidCode_Message"]).HandleErrors();
                    }
                        
                });
            }
        }
    }
}