﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace apcurium.MK.Booking.IBS
{
    public class IBSOrderDetails
    {

        public double? Toll { get; set; }
        public double? Fare { get; set; }
        public double? Tip { get; set; }
        public string VehicleNumber { get; set; }
        public string CallNumber { get; set; }
    }
}
