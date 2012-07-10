using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TinyIoC;
using apcurium.MK.Booking.Mobile.Practices;
using apcurium.MK.Booking.Mobile.Client.Localization;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Mobile.Client.Diagnostic;

namespace apcurium.MK.Booking.Mobile.Client
{
    public class AppModule : IModule
    {

        public AppModule(TaxiMobileApplication app)
        {

            App = app;
            app.PackageManager.GetPackageInfo(app.PackageName, 0);
        }

        public TaxiMobileApplication App { get; set; }
        public void Initialize()
        {
            TinyIoCContainer.Current.Register<IAppSettings>( new AppSettings(App));
            TinyIoCContainer.Current.Register<IAppContext>(new AppContext(App));
            TinyIoCContainer.Current.Register<IAppResource, ResourceManager>();
            TinyIoCContainer.Current.Register<ILogger, LoggerImpl>();
            //ServiceLocator.Current.Register<IAppResource, ResourceManager>();
            //ServiceLocator.Current.RegisterSingleInstance2<IAppSettings>(new AppSettings(App));
            //ServiceLocator.Current.Register<ILogger,LoggerImpl>();
            //ServiceLocator.Current.RegisterSingleInstance2<IAppContext>(new AppContext(App));
        
        }
    }
}