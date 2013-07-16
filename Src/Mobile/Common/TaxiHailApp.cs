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
using MK.Booking.Api.Client;
using apcurium.MK.Booking.Api.Client.Cmt.Payments;
using MK.Booking.Api.Client.TaxiHail;
using apcurium.MK.Booking.Api.Client.Payments;
using apcurium.MK.Booking.Api.Client.Payments.Braintree;
using apcurium.MK.Common.Diagnostic;

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
            var container = TinyIoCContainer.Current;
            container.Register<ITinyMessengerHub, TinyMessengerHub>();

            container.Register<IAccountServiceClient>((c, p) => 
                                                                     new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, null, c.Resolve<IPaymentServiceClient>()),
                                                                     "NotAuthenticated");
            
            container.Register<IAccountServiceClient>((c, p) =>
			                                                         new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c), c.Resolve<IPaymentServiceClient>()),
                                                                     "Authenticate");
            
            container.Register<IAccountServiceClient>((c, p) => new AccountServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c),c.Resolve<IPaymentServiceClient>()));

            container.Register<ReferenceDataServiceClient>((c, p) => new ReferenceDataServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            container.Register<PopularAddressesServiceClient>((c, p) => new PopularAddressesServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            container.Register<TariffsServiceClient>((c, p) => new TariffsServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            container.Register<PushNotificationRegistrationServiceClient>((c, p) => new PushNotificationRegistrationServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            container.Register<OrderServiceClient>((c, p) => new OrderServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            container.Register<IAuthServiceClient>((c, p) => new AuthServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));
            
            container.Register<ApplicationInfoServiceClient>((c, p) => new ApplicationInfoServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));

            container.Register<IConfigurationManager>((c, p) => new ConfigurationClientService(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c), c.Resolve<ILogger>()));

            container.Register<IAccountService, AccountService>();
            container.Register<IBookingService, BookingService>();

            container.Register<ITutorialService, TutorialService>();



            container.Register<IGeolocService, GeolocService>();
            container.Register<IGoogleService, GoogleService>();
            container.Register<IApplicationInfoService, ApplicationInfoService>();

            container.Register<IPriceCalculator, PriceCalculator>();
            container.Register<IAddresses, Addresses>();
            container.Register<IDirections, Directions>();
            container.Register<IGeocoding, Geocoding>();
            container.Register<IPlaces, Places>();
            container.Register<IMapsApiClient, MapsApiClient>();
            container.Register<IPopularAddressProvider, PopularAddressProvider>();
            container.Register<ITariffProvider, TariffProvider>();
            // ***** PayPal *****
            container.Register<IPayPalExpressCheckoutService, PayPalExpressCheckoutService> ();
            container.Register<PayPalServiceClient> ((c, p) => new PayPalServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));



			container.Register<IPaymentServiceClient>((c, p) =>
			{
				var settings = c.Resolve<IConfigurationManager>().GetPaymentSettings();
				var baseUrl = c.Resolve<IAppSettings>().ServiceUrl;
				var sessionId = this.GetSessionId(c);

				return new PaymentClientDelegate(settings.PaymentMode,
				                                 new BraintreeServiceClient(baseUrl,sessionId,settings.BraintreeClientSettings.ClientKey), 
				                                 new CmtPaymentClient(baseUrl,sessionId, settings.CmtPaymentSettings) );
			});
            

            container.Register<IVehicleClient>((c, p) => new VehicleServiceClient(c.Resolve<IAppSettings>().ServiceUrl, this.GetSessionId(c)));


            container.Resolve<IMvxLifetime>().LifetimeChanged -= TaxiHailApp_LifetimeChanged;
            container.Resolve<IMvxLifetime>().LifetimeChanged += TaxiHailApp_LifetimeChanged;

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





