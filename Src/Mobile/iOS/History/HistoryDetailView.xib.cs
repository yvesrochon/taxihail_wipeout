
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using apcurium.Framework.Extensions;
using TinyIoC;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.AppServices;
using TinyMessenger;
using apcurium.MK.Booking.Mobile.Messages;

namespace apcurium.MK.Booking.Mobile.Client
{
    public partial class HistoryDetailView : UIViewController
    {
        private HistoryTabView _parent;
        private Order _data;

        #region Constructors

        // The IntPtr and initWithCoder constructors are required for items that need 
        // to be able to be created from a xib rather than from managed code

        public HistoryDetailView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        [Export("initWithCoder:")]
        public HistoryDetailView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        public HistoryDetailView(HistoryTabView parent) : base("HistoryDetailView", null)
        {
            _parent = parent;
            Initialize();
        }

        void Initialize()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Assets/background.png"));
            

            
            this.NavigationItem.HidesBackButton = false;
            this.NavigationItem.TitleView = new TitleView(null, Resources.GetValue("View_HistoryDetail"), true);

            lblConfirmationNo.Text = Resources.HistoryDetailConfirmationLabel;
            lblRequested.Text = Resources.HistoryDetailRequestedLabel;
            lblOrigin.Text = Resources.HistoryDetailOriginLabel;
            lblDestination.Text = Resources.HistoryDetailDestinationLabel;
            lblStatus.Text = Resources.HistoryDetailStatusLabel;
            lblPickupDate.Text = Resources.HistoryDetailPickupDateLabel;
            lblAptRingCode.Text = Resources.HistoryDetailAptRingCodeLabel;

            btnRebook.SetTitle(Resources.HistoryDetailRebookButton, UIControlState.Normal);
            
            
            btnCancel.SetTitle(Resources.StatusActionCancelButton, UIControlState.Normal);
            btnStatus.SetTitle(Resources.HistoryViewStatusButton, UIControlState.Normal);
			btnSendReceipt.SetTitle (Resources.HistoryViewSendReceiptButton, UIControlState.Normal);
		    AppButtons.FormatStandardButton((GradientButton)btnHide, Resources.DeleteButton, AppStyle.ButtonColor.Red );

            btnCancel.TouchUpInside += CancelTouchUpInside;
            btnStatus.TouchUpInside += StatusTouchUpInside;
			btnSendReceipt.TouchUpInside += SendReceiptTouchUpInside;
            
            btnCancel.Hidden = true;
            btnStatus.Hidden = true;
			btnSendReceipt.Hidden = true;
            
            
            btnHide.TouchUpInside += HideTouchUpInside;          
            btnRebook.TouchUpInside += RebookTouched;
            RefreshData();
        }

        void StatusTouchUpInside(object sender, EventArgs e)
        {
            AppContext.Current.LastOrder = _data.Id;
			InvokeOnMainThread(() => TinyIoCContainer.Current.Resolve<ITinyMessengerHub>().Publish(new RebookRequested(this, null)));
			this.NavigationController.PopToRootViewController( true ); 
        }

        void CancelTouchUpInside(object sender, EventArgs e)
        {
			TinyIoCContainer.Current.Resolve<IBookingService>().RemoveFromHistory( _data.Id );
            View.UserInteractionEnabled = false;
            
            ThreadHelper.ExecuteInThread(() =>
            {
                try
                {
                    var isSuccess = TinyIoCContainer.Current.Resolve<IBookingService>().CancelOrder( _data.Id);
                    
                    if (isSuccess)
                    {
                        RefreshStatus();
                    }
                    else
                    {
                        
                        MessageHelper.Show(Resources.StatusConfirmCancelRideErrorTitle, Resources.StatusConfirmCancelRideError);
                    }
                }
                finally
                {
                    InvokeOnMainThread(() =>
                    {
                        LoadingOverlay.StopAnimatingLoading();
                        View.UserInteractionEnabled = true;
                    }
                    );
                }
            }
            );
        }

		void SendReceiptTouchUpInside(object sender, EventArgs e)
		{
			View.UserInteractionEnabled = false;
			
			ThreadHelper.ExecuteInThread(() =>
			                             {
				try
				{
					var isSuccess = TinyIoCContainer.Current.Resolve<IBookingService>().SendReceipt( _data.Id);
					
					if (isSuccess)
					{
						MessageHelper.Show(Resources.HistoryViewSendReceiptSuccess);
					}
					else
					{
						
						MessageHelper.Show(Resources.HistoryViewSendReceiptError);
					}
				}
				finally
				{
					InvokeOnMainThread(() =>
					                   {
						LoadingOverlay.StopAnimatingLoading();
						View.UserInteractionEnabled = true;
					}
					);
				}
			}
			);
		}

        void RebookTouched(object sender, EventArgs e)
        {
			InvokeOnMainThread( () => NavigationController.PopToRootViewController(true) );

			TinyIoCContainer.Current.Resolve<ITinyMessengerHub>().Publish(new RebookRequested(this, _data));
        }

        void HideTouchUpInside(object sender, EventArgs e)
        {
			TinyIoCContainer.Current.Resolve<IBookingService>().RemoveFromHistory( _data.Id );

            this.NavigationController.PopViewControllerAnimated(true);
        }

        public void LoadData(Order data)
        {
            _data = data;
        }

        private void RefreshData()
        {
            if (txtDestination != null)
            {
                if ( _data.IBSOrderId.HasValue )
                {
                    txtConfirmationNo.Text = "#" + _data.IBSOrderId.ToString();
                }
             

                txtRequested.Text = _data.PickupDate.ToShortDateString() + " - " + _data.PickupDate.ToShortTimeString();
                txtOrigin.Text = _data.PickupAddress.FullAddress;
                txtAptCode.Text = FormatAptRingCode(_data.PickupAddress.Apartment, _data.PickupAddress.RingCode);
                
                txtDestination.Text = _data.DropOffAddress.FullAddress.HasValue() ? _data.DropOffAddress.FullAddress : Resources.ConfirmDestinationNotSpecified;
                txtPickupDate.Text = FormatDateTime(_data.PickupDate, _data.PickupDate);
                
                txtStatus.Text = Resources.LoadingMessage;
                
                
                RefreshStatus();
                // _data.Status;                
            }
        }

        private void RefreshStatus()
        {
            ThreadHelper.ExecuteInThread(() =>
            {
            
                
                var status = TinyIoCContainer.Current.Resolve<IBookingService>().GetOrderStatus( _data.Id);
                
                bool isCompleted = TinyIoCContainer.Current.Resolve<IBookingService>().IsStatusCompleted(status.IBSStatusId);
				bool isDone      = TinyIoCContainer.Current.Resolve<IBookingService>().IsStatusDone(status.IBSStatusId);
                
                InvokeOnMainThread(() => txtStatus.Text = status.IBSStatusDescription);
                InvokeOnMainThread(() => btnCancel.Hidden = isCompleted);
                InvokeOnMainThread(() => btnStatus.Hidden = isCompleted);
				InvokeOnMainThread(() => btnHide.Hidden = !isCompleted);
				InvokeOnMainThread(() => btnSendReceipt.Hidden = !isDone);
            }
            );
        }

        private string FormatDateTime(DateTime? pickupDate, DateTime? pickupTime)
        {
            string result = pickupDate.HasValue ? pickupDate.Value.ToShortDateString() : Resources.DateToday;
            result += @" / ";
            result += pickupTime.HasValue ? pickupTime.Value.ToShortTimeString() : Resources.TimeNow;
            return result;
        }

        private string FormatAptRingCode(string apt, string rCode)
        {
            string result = apt.HasValue() ? apt : Resources.ConfirmNoApt;
            result += @" / ";
            result += rCode.HasValue() ? rCode : Resources.ConfirmNoRingCode;
            return result;
        }
        
        #endregion
    }
}

