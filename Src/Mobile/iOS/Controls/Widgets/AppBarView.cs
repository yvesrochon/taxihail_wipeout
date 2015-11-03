using System;
using Foundation;
using UIKit;
using CoreGraphics;
using apcurium.MK.Booking.Mobile.Client.Extensions.Helpers;
using apcurium.MK.Booking.Mobile.Client.Localization;
using apcurium.MK.Booking.Mobile.Client.Extensions;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using apcurium.MK.Booking.Mobile.ViewModels.Orders;
using apcurium.MK.Common.Configuration;
using Cirrious.CrossCore;
using apcurium.MK.Booking.Mobile.Client.Views;
using apcurium.MK.Booking.Mobile.ViewModels;

namespace apcurium.MK.Booking.Mobile.Client.Controls.Widgets
{
    [Register("AppBarView")]
    public class AppBarView : MvxView
    {
        protected UIView Line { get; set; }

        public AppBarView (IntPtr ptr):base(ptr)
        {
            Initialize ();
        }

        public AppBarView ()
        {
            Initialize ();
        }

		BookingBarNormalBooking _bookingBarNormalBooking;
		BookingBarManualRideLinQ _bookingBarManualRideLinQ;
		BookingBarAirportBooking _bookingBarAirportBooking;
		BookingBarConfirmation _bookingBarConfirmation;
		BookingBarEdit _bookingBarEdit;
		BookingBarInTripNormalBooking _bookingBarInTripNormalBooking;
		BookingBarInTripManualRideLinQBooking _bookingBarInTripManualRideLinQBooking;


        void Initialize ()
        {
            BackgroundColor = UIColor.White;

            Line = new UIView()
            {
                BackgroundColor = UIColor.FromRGB(140, 140, 140)
            };

            AddSubview(Line);

			_bookingBarNormalBooking = BookingBarNormalBooking.LoadViewFromFile();
			Add(_bookingBarNormalBooking);

			_bookingBarManualRideLinQ = BookingBarManualRideLinQ.LoadViewFromFile();
			Add(_bookingBarManualRideLinQ);

			_bookingBarAirportBooking = BookingBarAirportBooking.LoadViewFromFile();
			Add(_bookingBarAirportBooking);

			_bookingBarConfirmation = BookingBarConfirmation.LoadViewFromFile();
			Add(_bookingBarConfirmation);

			_bookingBarEdit = BookingBarEdit.LoadViewFromFile();
			Add(_bookingBarEdit);

			_bookingBarInTripNormalBooking = BookingBarInTripNormalBooking.LoadViewFromFile();
			Add(_bookingBarInTripNormalBooking);

			_bookingBarInTripManualRideLinQBooking = BookingBarInTripManualRideLinQBooking.LoadViewFromFile();
			Add(_bookingBarInTripManualRideLinQBooking);

			this.DelayBind(DataBinding);
        }

		void DataBinding()
		{
			var setBooking = this.CreateBindingSet<AppBarView, HomeViewModel>();

			setBooking.Bind(_bookingBarNormalBooking).For(v => v.DataContext).To(vm => vm.BottomBar);
			setBooking.Bind(_bookingBarManualRideLinQ).For(v => v.DataContext).To(vm => vm.BottomBar);
			setBooking.Bind(_bookingBarAirportBooking).For(v => v.DataContext).To(vm => vm.BottomBar);
			setBooking.Bind(_bookingBarConfirmation).For(v => v.DataContext).To(vm => vm.BottomBar);
			setBooking.Bind(_bookingBarEdit).For(v => v.DataContext).To(vm => vm.BottomBar);

			setBooking.Apply();

			var setBookingInTrip = this.CreateBindingSet<AppBarView, HomeViewModel>();

			setBookingInTrip.Bind(_bookingBarInTripNormalBooking).For(v => v.DataContext).To(vm => vm);
			setBookingInTrip.Bind(_bookingBarInTripManualRideLinQBooking).For(v => v.DataContext).To(vm => vm);

			setBookingInTrip.Apply();
		}

		public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (Line != null)
            {
                Line.Frame = new CGRect(0, 0, Frame.Width, UIHelper.OnePixel);
            }
        }
	}
}