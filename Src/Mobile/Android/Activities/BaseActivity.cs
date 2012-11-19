using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.GoogleMaps;
using Cirrious.MvvmCross.Binding.Android.Views;
using Cirrious.MvvmCross.Interfaces.ViewModels;

namespace apcurium.MK.Booking.Mobile.Client.Activities
{
    public abstract class BaseActivity : Activity
    {
        protected abstract int ViewTitleResourceId { get; }




        protected override void OnResume()
        {
            base.OnResume();
            
            var txt = FindViewById<TextView>(Resource.Id.ViewTitle);
            if (txt != null)
            {
                txt.Text = GetString(ViewTitleResourceId);
            }
        }
    }


    public abstract class BaseMapActivity : MapActivity
    {
        protected abstract int ViewTitleResourceId { get; }


        protected override void OnResume()
        {
            base.OnResume();

            var txt = FindViewById<TextView>(Resource.Id.ViewTitle);
            txt.Text = GetString(ViewTitleResourceId);
        }
    }

    public abstract class BaseBindingActivity<TViewModel> : MvxBindingActivityView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected abstract int ViewTitleResourceId { get; }


        protected override void OnResume()
        {
            base.OnResume();

            var txt = FindViewById<TextView>(Resource.Id.ViewTitle);
            txt.Text = GetString(ViewTitleResourceId);
        }

        protected override void OnPause()
        {
            base.OnPause();
            //var locmgr =(LocationManager) Application.Context.GetSystemService(Context.LocationService);
              //  locmgr.
            //Context.LocationService.
        }
    }

    public abstract class BaseListActivity : ListActivity
    {
        protected abstract int ViewTitleResourceId { get; }


        protected override void OnResume()
        {
            base.OnResume();

            var txt = FindViewById<TextView>(Resource.Id.ViewTitle);
            txt.Text = GetString(ViewTitleResourceId);
        }
    }

    
    
}