using System;
using apcurium.MK.Booking.Api.Contract.Requests.Payment;
using apcurium.MK.Booking.Api.Contract.Resources.Payments;

namespace apcurium.MK.Booking.Api.Services.Payment
{
    public interface IPaymentService
    {
        PreAuthorizePaymentResponse PreAuthorize(Guid orderId, string email, string cardToken, decimal amountToPreAuthorize);
        CommitPreauthorizedPaymentResponse CommitPayment(CommitPaymentRequest request);
        DeleteTokenizedCreditcardResponse DeleteTokenizedCreditcard(DeleteTokenizedCreditcardRequest request);
        PairingResponse Pair(PairingForPaymentRequest request);
        BasePaymentResponse Unpair(UnpairingForPaymentRequest request);
        void Void(Guid orderId);
    }
}