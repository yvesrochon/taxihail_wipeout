﻿using System;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace apcurium.MK.Booking.Api.Contract.Requests
{
    [Authenticate]
    [RestService("/account/bookingsettings", "PUT")]
    public class BookingSettingsRequest : BaseDTO
    {
        public string Name { get; set; }        

        public string Phone { get; set; }

        public int Passengers { get; set; }

        public int VehicleTypeId { get; set; }

        public int ChargeTypeId { get; set; }

        public int ProviderId { get; set; }

        public int NumberOfTaxi { get; set; }
    }
}