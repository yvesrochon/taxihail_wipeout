﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.EventSourcing;

namespace apcurium.MK.Booking.Events
{
    public class FavoriteAddressAdded : VersionedEvent
    {
        public string FriendlyName { get; set; }
        public string FullAddress { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Apartment { get; set; }
        public string RingCode { get; set; }
    }
}
