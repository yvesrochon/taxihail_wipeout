﻿#region

using System;
using System.Linq;
using apcurium.MK.Booking.CommandBuilder;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Booking.Database;
using apcurium.MK.Booking.Events;
using apcurium.MK.Booking.ReadModel;
using apcurium.MK.Booking.ReadModel.Query;
using apcurium.MK.Booking.ReadModel.Query.Contract;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Extensions;
using Infrastructure.Messaging;
using Infrastructure.Messaging.Handling;

#endregion

namespace apcurium.MK.Booking.EventHandlers.Integration
{
    public class MailSender : IIntegrationEventHandler,
        IEventHandler<PayPalExpressCheckoutPaymentCompleted>,
        IEventHandler<CreditCardPaymentCaptured>
    {
        private readonly ICommandBus _commandBus;
        private readonly Func<BookingDbContext> _contextFactory;
        private readonly ICreditCardDao _creditCardDao;
        private readonly IPromotionDao _promotionDao;

        public MailSender(Func<BookingDbContext> contextFactory,
            ICommandBus commandBus,
            ICreditCardDao creditCardDao,
            IPromotionDao promotionDao
            )
        {
            _contextFactory = contextFactory;
            _commandBus = commandBus;
            _creditCardDao = creditCardDao;
            _promotionDao = promotionDao;
        }

        public void Handle(CreditCardPaymentCaptured @event)
        {
            if (@event.IsNoShowFee)
            {
                // Don't message user
                return;
            }

            SendReceipt(@event.OrderId, @event.AmountSavedByPromotion);
        }

        public void Handle(PayPalExpressCheckoutPaymentCompleted @event)
        {
            SendReceipt(@event.OrderId);
        }
        
        private void SendReceipt(Guid orderId, decimal amountSavedByPromotion = 0m)
        {
            using (var context = _contextFactory.Invoke())
            {
                var order = context.Find<OrderDetail>(orderId);
                var orderStatus = context.Find<OrderStatusDetail>(orderId);
                if (orderStatus != null)
                {
                    var orderPayment = context.Set<OrderPaymentDetail>().FirstOrDefault(p => p.OrderId == orderStatus.OrderId && p.IsCompleted );

                    var account = context.Find<AccountDetail>(orderStatus.AccountId);

                    CreditCardDetails card = null;
                    if (orderPayment != null && orderPayment.CardToken.HasValue())
                    {
                        card = _creditCardDao.FindByToken(orderPayment.CardToken);
                    }

                    if (orderPayment != null)
                    {
                        var promoUsed = _promotionDao.FindByOrderId(orderId);

                        var command = SendReceiptCommandBuilder.GetSendReceiptCommand(order, account,
                            orderStatus.VehicleNumber, orderStatus.DriverInfos,
                            Convert.ToDouble(orderPayment.Meter), 0, Convert.ToDouble(orderPayment.Tip), 0, orderPayment,
                            Convert.ToDouble(amountSavedByPromotion), promoUsed, card);
                        
                        _commandBus.Send(command);
                    }
                }
            }
        }
    }
}
