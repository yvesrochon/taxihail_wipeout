﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apcurium.MK.Booking.Api.Contract.Resources
{
    public class ManualRideLinq : BaseDto
    {
        public Guid OrderId { get; set; }
        public Guid AccountId { get; set; }
        public string PairingCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsCancelled { get; set; }
        public double Distance { get; set; }
        public double? Total { get; set; }
        public double? Fare { get; set; }
        public double? FareAtAlternateRate { get; set; }
        public double? Toll { get; set; }
        public double? Extra { get; set; }
        public double? Tip { get; set; }
        public double? Surcharge { get; set; }
        public double? Tax { get; set; }
        public double? RateAtTripStart { get; set; }
        public double? RateAtTripEnd { get; set; }
        public string RateChangeTime { get; set; }
        public string Medallion { get; set; }
    }
}
