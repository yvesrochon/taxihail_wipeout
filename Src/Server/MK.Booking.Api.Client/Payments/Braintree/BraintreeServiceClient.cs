﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using apcurium.MK.Booking.Api.Client.TaxiHail;
using apcurium.MK.Booking.Api.Contract.Requests.Payment;
using apcurium.MK.Booking.Api.Contract.Requests.Payment.Braintree;
using apcurium.MK.Booking.Api.Contract.Resources.Payments;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Common.Resources;
using BraintreeEncryption.Library;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.ReadModel;
using apcurium.MK.Common;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Enumeration;
using CreditCardDetails = apcurium.MK.Booking.Api.Contract.Resources.CreditCardDetails;
#if !CLIENT
using apcurium.MK.Booking.Api.Client.Extensions;
#endif

namespace apcurium.MK.Booking.Api.Client.Payments.Braintree
{
	public class BraintreeServiceClient : BaseServiceClient, IPaymentServiceClient
    {
        public BraintreeServiceClient(string url, string sessionId, string clientKey, IPackageInfo packageInfo, IConnectivityService connectivityService)
            : base(url, sessionId, packageInfo, connectivityService)
        {
            ClientKey = clientKey;
        }

        protected string ClientKey { get; set; }


        public string[] EncryptCreditCard(string creditCardNumber, DateTime expiryDate, string cvv)
        {
            var braintree = new BraintreeEncrypter(ClientKey);
            var encryptedNumber = braintree.Encrypt(creditCardNumber);
            var encryptedExpirationDate = braintree.Encrypt(expiryDate.ToString("MM/yyyy", CultureInfo.InvariantCulture));
            var encryptedCvv = braintree.Encrypt(cvv);

            return new[]
            {
                encryptedNumber,
                encryptedExpirationDate,
                encryptedCvv
            };
        }

	    public Task<TokenizedCreditCardResponse> Tokenize(string creditCardNumber, string nameOnCard, DateTime expiryDate, string cvv, string kountSessionId, string zipCode, Account account)
        {
            throw new NotSupportedException("This method is not supported for Braintree vZero. Use AddPaymentMethod instead");
        }
        
        public Task<DeleteTokenizedCreditcardResponse> ForgetTokenizedCard(string cardToken)
        {
            return Client.DeleteAsync(new DeleteTokenizedCreditcardRequest
            {
                CardToken = cardToken
            });
        }

        public Task<BasePaymentResponse> ValidateTokenizedCard(CreditCardDetails creditCard, string cvv, string kountSessionId, Account account)
        {
            return Task.FromResult(new BasePaymentResponse { IsSuccessful = true });
        }

        public Task<OverduePayment> GetOverduePayment()
        {
            return Client.GetAsync<OverduePayment>("/account/overduepayment");
        }

        public Task<SettleOverduePaymentResponse> SettleOverduePayment()
        {
            return Client.PostAsync(new SettleOverduePaymentRequest());
        }

		public Task<GenerateClientTokenResponse> GenerateClientTokenResponse()
		{
			return Client.GetAsync(new GenerateClientTokenBraintreeRequest());
		}

		public Task<TokenizedCreditCardResponse> AddPaymentMethod(string nonce, PaymentMethods method, Guid? creditCardId, string cardholderName = null)
		{
			return Client.PostAsync(new AddPaymentMethodRequest()
			{
				Nonce = nonce,
                CardholderName = cardholderName,
                PaymentMethod = method,
                CreditCardId = creditCardId
			});
		}
    }
}