﻿using System;
using System.Threading;
using apcurium.MK.Booking.Api.Contract.Requests.Payment;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Booking.ReadModel.Query.Contract;
using apcurium.MK.Booking.Services;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Resources;
using Infrastructure.Messaging;
using ServiceStack.ServiceInterface;

namespace apcurium.MK.Booking.Api.Services.Payment
{
    public class OverduePaymentService : Service
    {
        private readonly ICommandBus _commandBus;
        private readonly IOverduePaymentDao _overduePaymentDao;
        private readonly IAccountDao _accountDao;
        private readonly IOrderDao _orderDao;
        private readonly IOrderPaymentDao _orderPaymentDao;
        private readonly IPromotionDao _promotionDao;
        private readonly IPaymentService _paymentService;
        private readonly IServerSettings _serverSettings;

        public OverduePaymentService(
            ICommandBus commandBus,
            IOverduePaymentDao overduePaymentDao,
            IAccountDao accountDao,
            IOrderDao orderDao,
            IOrderPaymentDao orderPaymentDao,
            IPromotionDao promotionDao,
            IPaymentService paymentService,
            IServerSettings serverSettings)
        {
            _commandBus = commandBus;
            _overduePaymentDao = overduePaymentDao;
            _accountDao = accountDao;
            _orderDao = orderDao;
            _orderPaymentDao = orderPaymentDao;
            _promotionDao = promotionDao;
            _paymentService = paymentService;
            _serverSettings = serverSettings;
        }

        public object Get(OverduePaymentRequest request)
        {
            var session = this.GetSession();
            var accountId = new Guid(session.UserAuthId);

            return _overduePaymentDao.FindNotPaidByAccountId(accountId);
        }

        public object Post(SettleOverduePaymentRequest request)
        {
            var session = this.GetSession();
            var accountId = new Guid(session.UserAuthId);

            var overduePayment = _overduePaymentDao.FindNotPaidByAccountId(accountId);
            if (overduePayment == null)
            {
                return new SettleOverduePaymentResponse
                {
                    IsSuccessful = true,
                    Message = "No overdue payment to settle"
                };
            }

            var accountDetail = _accountDao.FindById(accountId);

            var payment = _orderPaymentDao.FindByOrderId(overduePayment.OrderId);
            var reAuth = payment != null;

            var preAuthResponse = _paymentService.PreAuthorize(overduePayment.OrderId, accountDetail, overduePayment.OverdueAmount, reAuth, true);
            if (preAuthResponse.IsSuccessful)
            {
                // Wait for payment to be created
                Thread.Sleep(500);

                var commitResponse = _paymentService.CommitPayment(
                    overduePayment.OrderId,
                    accountDetail,
                    overduePayment.OverdueAmount,
                    overduePayment.OverdueAmount,
                    overduePayment.OverdueAmount,
                    0,
                    preAuthResponse.TransactionId,
                    preAuthResponse.ReAuthOrderId);

                if (commitResponse.IsSuccessful)
                {
                    // Go fetch declined order, and send its receipt
                    var paymentDetail = _orderPaymentDao.FindByOrderId(overduePayment.OrderId);
                    var promotion = _promotionDao.FindByOrderId(overduePayment.OrderId);

                    var pairingInfo = _orderDao.FindOrderPairingById(overduePayment.OrderId);
                    var tipAmount = FareHelper.GetTipAmountFromTotalIncludingTip(overduePayment.OverdueAmount, pairingInfo.AutoTipPercentage ?? _serverSettings.ServerData.DefaultTipPercentage);
                    var meterAmount = overduePayment.OverdueAmount - tipAmount;

                    var fareObject = FareHelper.GetFareFromAmountInclTax(meterAmount, 
                        _serverSettings.ServerData.VATIsEnabled
                            ? _serverSettings.ServerData.VATPercentage
                            : 0);

                    var orderDetail = _orderDao.FindById(overduePayment.OrderId);

                    _commandBus.Send(new CaptureCreditCardPayment
                    {
                        IsSettlingOverduePayment = true,
                        NewCardToken = paymentDetail.CardToken,
                        AccountId = accountDetail.Id,
                        PaymentId = paymentDetail.PaymentId,
                        Provider = _paymentService.ProviderType(overduePayment.OrderId),
                        TotalAmount = overduePayment.OverdueAmount,
                        MeterAmount = fareObject.AmountExclTax,
                        TipAmount = tipAmount,
                        TaxAmount = fareObject.TaxAmount,
                        TollAmount = Convert.ToDecimal(orderDetail.Toll ?? 0),
                        SurchargeAmount = Convert.ToDecimal(orderDetail.Surcharge ?? 0),
                        AuthorizationCode = commitResponse.AuthorizationCode,
                        TransactionId = commitResponse.TransactionId,
                        PromotionUsed = promotion != null ? promotion.PromoId : default(Guid?),
                        AmountSavedByPromotion = promotion != null ? promotion.AmountSaved : 0
                    });

                    _commandBus.Send(new SettleOverduePayment
                    {
                        AccountId = accountId,
                        OrderId = overduePayment.OrderId
                    });

                    return new SettleOverduePaymentResponse
                    {
                        IsSuccessful = true
                    };
                }

                // Payment failed, void preauth
                _paymentService.VoidPreAuthorization(overduePayment.OrderId);
            }

            return new SettleOverduePaymentResponse
            {
                IsSuccessful = false
            };
        }
    }
}