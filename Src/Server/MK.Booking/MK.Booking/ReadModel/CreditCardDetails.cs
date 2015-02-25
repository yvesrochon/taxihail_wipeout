﻿#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace apcurium.MK.Booking.ReadModel
{
    public class CreditCardDetails
    {
        [Key]
        public Guid CreditCardId { get; set; }

        public Guid AccountId { get; set; }

        public string NameOnCard { get; set; }

        public string Token { get; set; }

        public string Last4Digits { get; set; }

        public string CreditCardCompany { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public bool IsDeactivated { get; set; }
    }
}