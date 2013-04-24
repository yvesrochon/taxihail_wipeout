using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;
using apcurium.Framework.Extensions;
using TinyIoC;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Extensions;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Mobile.Client.MapUtilities;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Booking.Mobile.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Views;
using TinyMessenger;
using apcurium.MK.Booking.Mobile.Messages;
using Cirrious.MvvmCross.Binding.Touch.ExtensionMethods;
using apcurium.MK.Booking.Mobile.Client.Binding;
using apcurium.MK.Booking.Mobile.Client.Extensions;

namespace apcurium.MK.Booking.Mobile.Client
{
    public partial class StatusView : BaseViewController<BookingStatusViewModel>
    {
        #region Constructors

        public StatusView () 
            : base(new MvxShowViewModelRequest<BookingStatusViewModel>( null, true, new Cirrious.MvvmCross.Interfaces.ViewModels.MvxRequestedBy()   ) )
        {
        }
        
        public StatusView (MvxShowViewModelRequest request) 
            : base(request)
        {
        }
        
        public StatusView (MvxShowViewModelRequest request, string nibName, NSBundle bundle) 
            : base(request, nibName, bundle)
        {
        }

        #endregion

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);
            NavigationController.NavigationBar.Hidden = false;
            NavigationItem.HidesBackButton = false;  

            if ( NavigationController.ViewControllers.Any ( vc=>vc is ConfirmationView ) )
            {
                var newNavStack = NavigationController.ViewControllers.Where (  vc=>!(vc is ConfirmationView ));
                NavigationController.SetViewControllers ( newNavStack.ToArray () , false );
            }
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            try {
                ViewModel.Load();
                NavigationItem.HidesBackButton = true;                
                View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("Assets/background.png"));

                View.BringSubviewToFront (lblTitle);
                View.BringSubviewToFront (lblStatus);
                lblTitle.Text = Resources.LoadingMessage;

                btnChangeBooking.SetTitle (Resources.ChangeBookingSettingsButton, UIControlState.Normal);
             
                AppButtons.FormatStandardButton ((GradientButton)btnCall, Resources.StatusCallButton, AppStyle.ButtonColor.Black);
                AppButtons.FormatStandardButton ((GradientButton)btnCancel, Resources.StatusCancelButton, AppStyle.ButtonColor.Red);
                AppButtons.FormatStandardButton ((GradientButton)btnNewRide, Resources.StatusNewRideButton, AppStyle.ButtonColor.Green);
                AppButtons.FormatStandardButton ((GradientButton)btnPay, Resources.StatusPayButton, AppStyle.ButtonColor.Green);

                this.NavigationItem.TitleView = new TitleView (null, Resources.GenericTitle, false);
                
                View.BringSubviewToFront (bottomBar);

                if ( ViewModel.IsCallButtonVisible )
                {
                    ViewModel.PropertyChanged+= (sender, e) => {
                        InvokeOnMainThread(()=>
                                           {
                            if(!ViewModel.IsCancelButtonVisible && !ViewModel.IsPayButtonVisible)
                            {
                                btnCall.SetX((View.Frame.Width - btnCancel.Frame.Width)/2)
                                    .SetWidth(btnCancel.Frame.Width);
                                
                                AppButtons.FormatStandardButton ((GradientButton)btnCall, Resources.StatusCallButton, AppStyle.ButtonColor.Black);
                            }
                        });
                    };

                    btnCancel.SetFrame(8, btnCancel.Frame.Y,  btnCancel.Frame.Width,  btnCancel.Frame.Height );
                    btnCall.Frame = new System.Drawing.RectangleF( 320 - 8 - btnCall.Frame.Width ,  btnCall.Frame.Y,  btnCall.Frame.Width,  btnCall.Frame.Height );
                    btnPay.SetFrame(btnCancel.Frame);
                }

                this.AddBindings (new Dictionary<object, string> ()                            
                {
                    { mapStatus, new B("Pickup","Pickup.Model")
                        .Add("TaxiLocation","OrderStatusDetail")
                        .Add("MapCenter","MapCenter") },

                    { lblTitle, new B("Text","StatusInfoText") },
                    { lblStatus, new B("Text","ConfirmationNoTxt") },
                    { btnCancel, new B("TouchUpInside","CancelOrder")
                        .Add("Hidden","IsCancelButtonVisible","BoolInverter")},

                    { btnPay, new B("TouchUpInside","PayForOrderCommand")
                        .Add("Hidden","IsPayButtonVisible","BoolInverter")},

                    { btnCall, new B("Hidden","IsCallButtonVisible","BoolInverter")
                        .Add("Enabled","IsCallButtonVisible")
                        .Add("TouchUpInside","CallCompany") },

                    { btnNewRide, new B("TouchUpInside","NewRide") }
                });
                mapStatus.Delegate = new AddressMapDelegate ();
                mapStatus.AddressSelectionMode = Data.AddressSelectionMode.None;
            
            } catch (Exception ex) {
                Logger.LogError (ex);
            }

            this.View.ApplyAppFont ();
        }
    }
}

