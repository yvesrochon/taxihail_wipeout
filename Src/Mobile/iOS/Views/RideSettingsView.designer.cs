// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace apcurium.MK.Booking.Mobile.Client
{
	[Register ("RideSettingsView")]
	partial class RideSettingsView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPhone { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblVehicleType { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblChargeType { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtPhone { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtVehicleType { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtChargeType { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scrollView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (lblPhone != null) {
				lblPhone.Dispose ();
				lblPhone = null;
			}

			if (lblVehicleType != null) {
				lblVehicleType.Dispose ();
				lblVehicleType = null;
			}

			if (lblChargeType != null) {
				lblChargeType.Dispose ();
				lblChargeType = null;
			}

			if (txtPhone != null) {
				txtPhone.Dispose ();
				txtPhone = null;
			}

			if (txtVehicleType != null) {
				txtVehicleType.Dispose ();
				txtVehicleType = null;
			}

			if (txtChargeType != null) {
				txtChargeType.Dispose ();
				txtChargeType = null;
			}

			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}

			if (lblPassword != null) {
				lblPassword.Dispose ();
				lblPassword = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}
		}
	}
}
