﻿using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using apcurium.MK.Booking.Api.Contract.Security;
using apcurium.MK.Booking.Security;

namespace apcurium.MK.Booking.Api.Contract.Requests
{

    [Authenticate]
    [AuthorizationRequired(ApplyTo.All, Permissions.Admin)]
    [RestService("/account/adminconfirm", "PUT")]
    public class AdminConfirmAccountRequest : BaseDTO
    {
        public string AccountEmail { get; set; }
    }
}