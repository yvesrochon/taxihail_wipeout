﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;

namespace apcurium.MK.Booking.Api.Contract.Requests
{
    [Authenticate]
    [RestService("/directions", "GET,OPTIONS")]    
    public class DirectionsRequest
    {
        public double? OriginLat { get; set; }
        public double? OriginLng { get; set; }

        public double? DestinationLat { get; set; }
        public double? DestinationLng { get; set; }
    }
}
