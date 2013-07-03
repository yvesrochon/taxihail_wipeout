﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;
using apcurium.MK.Booking.Api.Contract.Resources.Payments;

namespace apcurium.MK.Booking.Api.Contract.Requests.Braintree
{
    [Route("/payments/braintree/preAuthorizePayment", "POST")]
    public class PreAuthorizePaymentBraintreeRequest : IReturn<PreAuthorizePaymentResponse>
    {
        public decimal Amount { get; set; }

        public string CardToken { get; set; }

        public string OrderNumber { get; set; }
    }
}
