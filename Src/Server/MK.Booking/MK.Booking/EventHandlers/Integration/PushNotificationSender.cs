﻿#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using apcurium.MK.Booking.Database;
using apcurium.MK.Booking.Events;
using apcurium.MK.Booking.Maps.Geo;
using apcurium.MK.Booking.PushNotifications;
using apcurium.MK.Booking.ReadModel;
using apcurium.MK.Booking.Resources;
using apcurium.MK.Booking.Services;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Enumeration;
using Infrastructure.Messaging.Handling;

#endregion

namespace apcurium.MK.Booking.EventHandlers.Integration
{
    public class PushNotificationSender : IIntegrationEventHandler,
            IEventHandler<OrderStatusChanged>,
            IEventHandler<CreditCardPaymentCaptured>
    {
        private readonly INotificationService _notificationService;

        public PushNotificationSender(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Handle(OrderStatusChanged @event)
        {
            switch (@event.Status.IBSStatusId)
            {
                case VehicleStatuses.Common.Assigned:
                    _notificationService.SendAssignedPush(@event.Status);
                    break;
                case VehicleStatuses.Common.Arrived:
                    _notificationService.SendArrivedPush(@event.Status);
                    break;
                case VehicleStatuses.Common.Loaded:
                    _notificationService.SendPairingInquiryPush(@event.Status);
                    break;
                case VehicleStatuses.Common.Timeout:
                    _notificationService.SendTimeoutPush(@event.Status);
                    break;
                default:
                    // No push notification for this order status
                    return;
            }
        }

        public void Handle(CreditCardPaymentCaptured @event)
        {
            _notificationService.SendPaymentCapturePush(@event.OrderId, @event.Amount);
        }
    }
}