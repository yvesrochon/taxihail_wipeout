﻿using System;
using apcurium.MK.Booking.Events;
using apcurium.MK.Booking.ReadModel;
using apcurium.MK.Booking.ReadModel.Query;
using apcurium.MK.Booking.Resources;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Enumeration;
using Infrastructure.Messaging.Handling;

namespace apcurium.MK.Booking.EventHandlers.Integration
{
    public class OrderPaymentManager :
        IIntegrationEventHandler,
        IEventHandler<PayPalExpressCheckoutPaymentCompleted>,
        IEventHandler<CreditCardPaymentCaptured>
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly IOrderDao _dao;
        private readonly IIBSOrderService _ibs;

        public OrderPaymentManager(IOrderDao dao, IIBSOrderService ibs, IConfigurationManager configurationManager)
        {
            _dao = dao;
            _ibs = ibs;
            _configurationManager = configurationManager;
        }

        public void Handle(CreditCardPaymentCaptured @event)
        {
            SendPaymentConfirmationToDriver(@event.OrderId, @event.Amount, PaymentType.CreditCard.ToString(),
                @event.Provider.ToString(), @event.TransactionId, @event.AuthorizationCode);
        }

        public void Handle(PayPalExpressCheckoutPaymentCompleted @event)
        {
            // Send message to driver
            SendPaymentConfirmationToDriver(@event.OrderId, @event.Amount, PaymentType.PayPal.ToString(),
                PaymentProvider.PayPal.ToString(), @event.TransactionId, @event.PayPalPayerId);
        }

        private void SendPaymentConfirmationToDriver(Guid orderId, decimal amount, string type, string provider,
            string transactionId, string authorizationCode)
        {
            // Send message to driver
            OrderStatusDetail orderStatusDetail = _dao.FindOrderStatusById(orderId);
            if (orderStatusDetail == null) throw new InvalidOperationException("Order Status not found");

            string applicationKey = _configurationManager.GetSetting("TaxiHail.ApplicationKey");
            var resources = new DynamicResources(applicationKey);

            string line1 = string.Format(resources.GetString("PaymentConfirmationToDriver1"), amount);
            line1 = line1.PadRight(32, ' ');
                //Padded with 32 char because the MDT displays line of 32 char.  This will cause to write the auth code on the second line
            string line2 = string.Format(resources.GetString("PaymentConfirmationToDriver2"), authorizationCode);
            _ibs.SendMessageToDriver(line1 + line2, orderStatusDetail.VehicleNumber);

            // Confirm to IBS that order was payed
            OrderDetail orderDetail = _dao.FindById(orderId);
            if (orderDetail == null) throw new InvalidOperationException("Order not found");
            if (orderDetail.IBSOrderId == null) throw new InvalidOperationException("IBSOrderId should not be null");

            _ibs.ConfirmExternalPayment(orderDetail.IBSOrderId.Value, amount, type, provider, transactionId,
                authorizationCode);
        }
    }
}