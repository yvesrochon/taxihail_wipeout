// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace apcurium.MK.Booking.Mobile.Client.Views
{
	[Register ("CreditCardsListView")]
	partial class CreditCardsListView
	{
		[Outlet]
		MonoTouch.UIKit.UITableView tableCardsList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableCardsList != null) {
				tableCardsList.Dispose ();
				tableCardsList = null;
			}
		}
	}
}