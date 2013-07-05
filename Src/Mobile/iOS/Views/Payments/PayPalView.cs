
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using apcurium.MK.Booking.Mobile.ViewModels.Payment;
using Cirrious.MvvmCross.Views;

namespace apcurium.MK.Booking.Mobile.Client.Views.Payments
{
    public partial class PayPalView : BaseViewController<PayPalViewModel>
    {
        public PayPalView(MvxShowViewModelRequest request) 
            : base(request)
        {
        }
		
        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
			
            // Release any cached data, images, etc that aren't in use.
        }
		
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            ViewModel.Load();

            webView.ShouldStartLoad = LoadHook;
            webView.LoadRequest(new NSUrlRequest(new NSUrl(ViewModel.Url)));
        }

        bool LoadHook (UIWebView sender, NSUrlRequest request, UIWebViewNavigationType navType)
        {
			if(request.Url.Scheme.StartsWith("taxihail"))
			{
				ViewModel.Finish.Execute();
				return false;
			}
			return true;
        }
    }
}

