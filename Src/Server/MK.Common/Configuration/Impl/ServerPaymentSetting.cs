﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MK.Common.Android.Configuration.Impl;

namespace apcurium.MK.Common.Configuration.Impl
{
    public class ServerPaymentSettings : ClientPaymentSettings
    {
        public ServerPaymentSettings() //for serialization
        {
        }

        public ServerPaymentSettings(Guid id)
        {
            Id = id;
            BraintreeServerSettings = new BraintreeServerSettings();
            PayPalServerSettings = new PayPalServerSettings(Guid.NewGuid());
        }

        [Key]
        public Guid Id { get; set; }

        
        public BraintreeServerSettings BraintreeServerSettings { get; set; }

        public PayPalServerSettings PayPalServerSettings { get; set; }
    }
}
