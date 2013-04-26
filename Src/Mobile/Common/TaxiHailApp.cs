using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Interfaces.Localization;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using MK.Booking.Mobile.Infrastructure.Mvx;
using TinyIoC;
using TinyMessenger;
using apcurium.MK.Booking.Api.Client.TaxiHail;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Api.Client;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Mobile.AppServices.Impl;
using apcurium.MK.Booking.Maps;
using apcurium.MK.Booking.Maps.Impl;
using apcurium.MK.Booking.Google.Impl;
using apcurium.MK.Booking.Google;
using apcurium.MK.Common.Configuration;
using Cirrious.MvvmCross.Interfaces.Platform.Location;
using System;
using ServiceStack.Text;
using apcurium.MK.Common.Provider;
using apcurium.MK.Booking.Api.Contract.Security;
using Cirrious.MvvmCross.Interfaces.Platform.Lifetime;
using System.Threading.Tasks;
using System.Collections.Generic;
using MK.Booking.Api.Client.Android;
using MK.Booking.Api.Client;

namespace apcurium.MK.Booking.Mobile
{
    public class TaxiHailApp  : MvxApplication
        , IMvxServiceProducer<IMvxStartNavigation>
    {    
      
        public TaxiHailApp()
            : this(default(IDictionary<string, string>))
        {
        }

        public TaxiHailApp(IDictionary<string, string> @params)
        {
            InitalizeServices();
            if(TinyIoCContainer.Current.Resolve<IAppSettings> ().PushNotificationsEnabled)
            {
                InitializePushNotifications();
            }
            InitializeStartNavigation(@params);
        }
        
        private void InitalizeServices()
        {
            TinyIoCContainer.Current.Register<ITinyMessengerHub, TinyMessengerHub>();

            TinyIoCContainer.Current.Register<IAccountServiceClient>((c, p) => 
                                                                     new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, null, c.Resolve<IPaymentClient>()),
                                                                     "NotAuthenticated");
            
            TinyIoCContainer.Current.Register<IAccountServiceClient>((c, p) =>
                                                                     new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c), c.Resolve<IPaymentClient>()),
                                                                     "Authenticate");
            
            TinyIoCContainer.Current.Register<IAccountServiceClient>((c, p) => new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c),c.Resolve<IPaymentClient>()));

            TinyIoCContainer.Current.Register<ReferenceDataServiceClient>((c, p) => new ReferenceDataServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            TinyIoCContainer.Current.Register<PopularAddressesServiceClient>((c, p) => new PopularAddressesServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            TinyIoCContainer.Current.Register<TariffsServiceClient>((c, p) => new TariffsServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
			TinyIoCContainer.Current.Register<PushNotificationRegistrationServiceClient>((c, p) => new PushNotificationRegistrationServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            TinyIoCContainer.Current.Register<OrderServiceClient>((c, p) => new OrderServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            TinyIoCContainer.Current.Register<IAuthServiceClient>((c, p) => new AuthServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            
            TinyIoCContainer.Current.Register<ApplicationInfoServiceClient>((c, p) => new ApplicationInfoServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            TinyIoCContainer.Current.Register<IConfigurationManager>((c, p) => new ConfigurationClientService(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            TinyIoCContainer.Current.Register<IAccountService, AccountService>();
            TinyIoCContainer.Current.Register<IBookingService, BookingService>();

            TinyIoCContainer.Current.Register<ITutorialService, TutorialService>();



            TinyIoCContainer.Current.Register<IGeolocService, GeolocService>();
            TinyIoCContainer.Current.Register<IGoogleService, GoogleService>();
            TinyIoCContainer.Current.Register<IApplicationInfoService, ApplicationInfoService>();

            TinyIoCContainer.Current.Register<IPriceCalculator, PriceCalculator>();
            TinyIoCContainer.Current.Register<IAddresses, Addresses>();
            TinyIoCContainer.Current.Register<IDirections, Directions>();
            TinyIoCContainer.Current.Register<IGeocoding, Geocoding>();
            TinyIoCContainer.Current.Register<IPlaces, Places>();
            TinyIoCContainer.Current.Register<IMapsApiClient, MapsApiClient>();
            TinyIoCContainer.Current.Register<IPopularAddressProvider, PopularAddressProvider>();
            TinyIoCContainer.Current.Register<ITariffProvider, TariffProvider>();
            TinyIoCContainer.Current.Register<ICreditCardAuthorizationService, CreditCardAuthorizationService>();


            TinyIoCContainer.Current.Resolve<IMvxLifetime>().LifetimeChanged -= TaxiHailApp_LifetimeChanged;
            TinyIoCContainer.Current.Resolve<IMvxLifetime>().LifetimeChanged += TaxiHailApp_LifetimeChanged;

            RefreshAppData();
        }


        void TaxiHailApp_LifetimeChanged(object sender, MvxLifetimeEventArgs e)
        {
            if ( e.LifetimeEvent == MvxLifetimeEvent.Deactivated )
            {
                ClearAppCache();
            }
            else if ( ( e.LifetimeEvent == MvxLifetimeEvent.ActivatedFromDisk ) || ( e.LifetimeEvent == MvxLifetimeEvent.ActivatedFromMemory )  )
            {
                Task.Factory.StartNew(() =>
                    {
                        ClearAppCache();
                        LoadAppCache();
                    });

            }
        }

        private void LoadAppCache()
        {
            TinyIoCContainer.Current.Resolve<IApplicationInfoService>().GetAppInfo();
            TinyIoCContainer.Current.Resolve<IAccountService>().GetReferenceData();
            TinyIoCContainer.Current.Resolve<IConfigurationManager>().GetSettings();
        }

        private static void ClearAppCache()
        {
            TinyIoCContainer.Current.Resolve<IApplicationInfoService>().ClearAppInfo();
            TinyIoCContainer.Current.Resolve<IAccountService>().ClearReferenceData();
            TinyIoCContainer.Current.Resolve<IConfigurationManager>().Reset();
        }

        private void RefreshAppData()
        {
			Task.Factory.StartNew(() =>
			                      {
				ClearAppCache();
				LoadAppCache();
			});
        }

        
        private string GetSessionId (TinyIoCContainer container)
        {
            var authData = container.Resolve<ICacheService> ().Get<AuthenticationData> ("AuthenticationData");
            var sessionId = authData == null ? null : authData.SessionId;
            if (sessionId == null) {
                sessionId = container.Resolve<ICacheService> ().Get<string>("SessionId");
            }
            return sessionId;
        }
        
        private void InitializeStartNavigation(IDictionary<string, string> @params)
        {
            var startApplicationObject = new StartNavigation(@params);
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);
        }

        private void InitializePushNotifications()
        {
            var accountService = TinyIoCContainer.Current.Resolve<IAccountService>();
            var pushService = TinyIoCContainer.Current.Resolve<IPushNotificationService>();
            if (accountService.CurrentAccount != null)
            {
                pushService.RegisterDeviceForPushNotifications();
            }
        }

        protected override IMvxViewModelLocator CreateDefaultViewModelLocator()
        {
            return new TinyIocViewModelLocator(); //base.CreateDefaultViewModelLocator();
        }
    }
}





