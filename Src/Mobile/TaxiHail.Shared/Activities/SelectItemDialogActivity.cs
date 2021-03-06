using Android.App;
using Android.OS;
using apcurium.MK.Booking.Mobile.Client.Helpers;
using apcurium.MK.Booking.Mobile.Messages;

namespace apcurium.MK.Booking.Mobile.Client.Activities
{
	[Activity(Label = "@string/MessageActivityName", Theme = "@android:style/Theme.Dialog")]
    public class SelectItemDialogActivity : Activity
    {
        private string[] _items;
        private string _ownerId;
        private string _title;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _title = Intent.GetStringExtra("Title");
            _ownerId = Intent.GetStringExtra("OwnerId");
            _items = Intent.GetStringArrayExtra("Items");
        }

        protected override void OnStart()
        {
            base.OnStart();
            ShowDialog();
        }

        private void ShowDialog()
        {
            AlertDialogHelper.Show(this, _title, _items, (s, e) => ReturnResult(e.Which));
        }

        private void ReturnResult(int itemIndex)
        {
			this.Services().MessengerHub.Publish(new SubNavigationResultMessage<int>(this, _ownerId, itemIndex));
            Finish();
        }
    }
}