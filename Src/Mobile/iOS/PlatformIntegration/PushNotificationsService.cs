using System;
using apcurium.MK.Booking.Mobile.AppServices.Impl;
using MonoTouch.Foundation;
using apcurium.MK.Booking.Api.Client.TaxiHail;
using MonoTouch.UIKit;
using apcurium.MK.Booking.Mobile.Infrastructure;

namespace apcurium.MK.Booking.Mobile.Client
{
    public class PushNotificationsService: BaseService, IPushNotificationService
    {
        public PushNotificationsService ()
        {
        }

        public void RegisterDeviceForPushNotifications ()
        {
            UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Alert
                                                                               | UIRemoteNotificationType.Badge
                                                                               | UIRemoteNotificationType.Sound);
        }

        public void SaveDeviceToken(string deviceToken)
        {
            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");
            
            //There's probably a better way to do this
            var strFormat = new NSString("%@");
            var newDeviceToken = deviceToken.ToString().Replace("<", "").Replace(">", "").Replace(" ", "");
            
            if (string.IsNullOrEmpty(oldDeviceToken))
            {
                base.UseServiceClient<PushNotificationRegistrationServiceClient>(service => {
                    service.Register(newDeviceToken);
                });
            }
            else if(!deviceToken.Equals(newDeviceToken))
            {
                base.UseServiceClient<PushNotificationRegistrationServiceClient>(service => {
                    service.Unregister(oldDeviceToken);
                    service.Register(newDeviceToken);
                });
            }


            
            //Save device token now
            NSUserDefaults.StandardUserDefaults.SetString(newDeviceToken, "PushDeviceToken");
            
            Console.WriteLine("Device Token: " + newDeviceToken);
        }
    }
}

