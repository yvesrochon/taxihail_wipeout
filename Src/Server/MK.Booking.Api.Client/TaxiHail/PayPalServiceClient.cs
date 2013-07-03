using System;
using apcurium.MK.Booking.Api.Client.TaxiHail;
using apcurium.MK.Booking.Api.Contract.Requests.Payment;

namespace MK.Booking.Api.Client.TaxiHail
{
    public class PayPalServiceClient: BaseServiceClient
    {
        public PayPalServiceClient (string url, string sessionId)
            :base(url, sessionId)
        {
            
        }

        public string SetExpressCheckoutForAmount(decimal amount)
        {
            var response = this.Client.Post (new PayPalRequest { Amount= amount });
            return response.CheckoutUrl;
        }
    }
}

