﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace apcurium.MK.Booking.ReadModel
{
    public class DefaultAddressDetails
    {
        [Key]
        public Guid Id { get; set; }

        public string FriendlyName { get; set; }

        public string Apartment { get; set; }

        public string FullAddress { get; set; }

        public string RingCode { get; set; }

        public string BuildingName { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string PlaceReference { get; set; }

        public string StreetNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }
    }
}
