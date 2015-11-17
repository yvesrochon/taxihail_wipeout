﻿#region

using apcurium.MK.Common.Enumeration;

#endregion

namespace apcurium.MK.Booking.Api.Contract.Requests
{
    [Authenticate]
    [Route("/account/pushnotifications/{DeviceToken}", "POST,DELETE")]
    public class PushNotificationRegistration
    {
        public string DeviceToken { get; set; }
        public string OldDeviceToken { get; set; }
        public PushNotificationServicePlatform Platform { get; set; }
    }
}