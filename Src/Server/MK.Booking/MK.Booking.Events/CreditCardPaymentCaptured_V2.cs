﻿using System;

namespace apcurium.MK.Booking.Events
{
    public class CreditCardPaymentCaptured_V2 : CreditCardPaymentCaptured
    {
        public Guid AccountId { get; set; }

        public decimal Tax { get; set; }

        public string NewCardToken { get; set; }

        public bool IsSettlingOverduePayment { get; set; }

        public bool IsForPrepaidOrder { get; set; }

        public bool IsCancellationFee { get; set; }
    }
}