﻿using System;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using DatabaseInitializer.OldEvents;
using Infrastructure.Sql.EventSourcing;
using Newtonsoft.Json;
using apcurium.MK.Booking.Events;
using log4net;
using OrderCompleted = DatabaseInitializer.OldEvents.OrderCompleted;

namespace DatabaseInitializer.Services
{
    public class EventsMigrator : IEventsMigrator
    {
        private readonly Func<EventStoreDbContext> _contextFactory;
        private readonly IServerSettings _serverSettings;
        private readonly JsonSerializer _serializer;
        private readonly JsonSerializer _deserializer;
        private ILog _logger;

        public EventsMigrator(Func<EventStoreDbContext> contextFactory, IServerSettings serverSettings)
        {
            
            _contextFactory = contextFactory;
            _serverSettings = serverSettings; // server settings comes from latest settings on old database
            //deserailize without type
            _deserializer = new JsonSerializer();
            //sereailize with type as expected in infrastructure
            _serializer = new JsonSerializer(){ TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple, TypeNameHandling = TypeNameHandling.All};
            _logger = LogManager.GetLogger("DatabaseInitializer");
        }

        public void Do()
        {
            var skip = 0;
            var hasMore = true;
            const int pageSize = 5000;
            while (hasMore)
            {
                using (var context = _contextFactory.Invoke())
                {
                    context.Database.CommandTimeout = 2000;
                    // order by date then by version in case two events happened at the same time
                    var events = context.Set<Event>()
                        .OrderBy(x => x.EventDate)
                        .ThenBy(x => x.Version)
                        .Skip(skip)
                        .Take(pageSize)
                        .ToList();
                

                    hasMore = events.Count == pageSize;
                    Console.WriteLine("Number of events migrated: " + (hasMore ? skip : (skip + events.Count)));
                    skip += pageSize;

                    // fix BraintreeClientSettings namespace problem
                    foreach (var message in events.Where(x => x.EventType == typeof(PaymentSettingUpdated).FullName).ToList())
                    {
                        message.Payload =
                            message.Payload.Replace("apcurium.MK.Common.Configuration.BraintreeClientSettings",
                                "apcurium.MK.Common.Configuration.Impl.BraintreeClientSettings");
                    }
                    context.SaveChanges();

                    // rename Order Pairing events
                    foreach (var message in events.Where(x =>
                                    x.EventType.Contains("OrderPairedForRideLinqCmtPayment") ||
                                    x.EventType.Contains("OrderUnpairedForRideLinqCmtPayment")))
                    {
                        message.Payload = message.Payload.Replace("OrderPairedForRideLinqCmtPayment",
                            "OrderPairedForPayment");
                        message.Payload = message.Payload.Replace("OrderUnpairedForRideLinqCmtPayment",
                            "OrderUnpairedForPayment");
                        message.EventType = message.EventType.Replace("OrderPairedForRideLinqCmtPayment",
                            "OrderPairedForPayment");
                        message.EventType = message.EventType.Replace("OrderUnpairedForRideLinqCmtPayment",
                            "OrderUnpairedForPayment");
                    }
                    context.SaveChanges();

                    // convert OrderCompleted to OrderStatusChanged
                    foreach (var message in events.Where(x => x.EventType.Contains("OrderCompleted")).ToList())
                    {
                        var @event = Deserialize<OrderCompleted>(message.Payload);
                        var newEvent = new OrderStatusChanged
                        {
                            EventDate = @event.EventDate,
                            SourceId = @event.SourceId,
                            Version = @event.Version,
                            Fare = @event.Fare,
                            Tax = @event.Tax,
                            Tip = @event.Tip,
                            Toll = @event.Toll,
                            IsCompleted = true
                        };
                        message.Payload = Serialize(newEvent);
                        message.EventType = message.EventType.Replace("OrderCompleted", "OrderStatusChanged");
                    }
                    context.SaveChanges();

                    // convert CreditCardPaymentCaptured to CreditCardPaymentCaptured_V2
                    foreach (var message in events.Where(x => x.EventType.Equals("apcurium.MK.Booking.Events.CreditCardPaymentCaptured")).ToList())
                    {
                        var @event = Deserialize<CreditCardPaymentCaptured>(message.Payload);
                        var newEvent = Convert(@event);
                        message.Payload = Serialize(newEvent);
                        message.EventType = message.EventType.Replace("CreditCardPaymentCaptured", "CreditCardPaymentCaptured_V2");
                    }
                    context.SaveChanges();

                    // convert OrderFareUpdated to OrderStatusChanged
                    foreach (var message in events.Where(x => x.EventType.Contains("OrderFareUpdated")).ToList())
                    {
                        var @event = Deserialize<OrderFareUpdated>(message.Payload);
                        var newEvent = new OrderStatusChanged
                        {
                            EventDate = @event.EventDate,
                            SourceId = @event.SourceId,
                            Version = @event.Version,
                            Fare = @event.Fare,
                            Tax = @event.Tax,
                            Tip = @event.Tip,
                            Toll = @event.Toll,
                            IsCompleted = false
                        };
                        message.Payload = Serialize(newEvent);
                        message.EventType = message.EventType.Replace("OrderFareUpdated", "OrderStatusChanged");
                    }
                    context.SaveChanges();

                    // update OrderStatusChanged containing a Status with an invalid pickup date
                    foreach (var message in events.Where(x => x.EventType.Contains("OrderStatusChanged") 
                                                        && !x.Payload.Contains("\"Status\":null"))
                                                        .ToList())
                    {
                        var @event = Deserialize<OrderStatusChanged>(message.Payload);

                        @event.Status.PickupDate = @event.Status.PickupDate < ((DateTime) SqlDateTime.MinValue)
                            ? (DateTime) SqlDateTime.MinValue
                            : @event.Status.PickupDate;

                        message.Payload = Serialize(@event);
                    }
                    context.SaveChanges();

                    // update AppSettings
                    foreach (var message in events.Where(x => x.EventType.Contains("AppSettingsAddedOrUpdated")))
                    {
                        message.Payload = message.Payload.Replace("\"Client.", "\"");
                        message.Payload = message.Payload.Replace("\"DistanceFormat\": \"KM\"", "\"DistanceFormat\": \"Km\"");
                        message.Payload = message.Payload.Replace("\"DistanceFormat\":\"KM\"", "\"DistanceFormat\":\"Km\"");
                    }
                    context.SaveChanges();
                }
            }
        }

        public string Serialize<T>(T data)
        {
            using (var writer = new StringWriter())
            {
                _serializer.Serialize(writer, data);
                return writer.ToString();
            }
        }
      
        public T Deserialize<T>(string serialized)
        {
            using (var reader = new StringReader(serialized))
            {
                var jsonReader = new JsonTextReader(reader);

                try
                {
                    return this._deserializer.Deserialize<T>(jsonReader);
                }
                catch (JsonSerializationException e)
                {
                    // Wrap in a standard .NET exception.
                    throw new SerializationException(e.Message, e);
                }
            }
        }

        private CreditCardPaymentCaptured_V2 Convert(CreditCardPaymentCaptured oldEvent)
        {
            var fareObject = Fare.FromAmountInclTax(System.Convert.ToDouble(oldEvent.Meter), _serverSettings.ServerData.VATIsEnabled ? _serverSettings.ServerData.VATPercentage : 0);

            return new CreditCardPaymentCaptured_V2
            {
                EventDate = oldEvent.EventDate,
                SourceId = oldEvent.SourceId,
                Version = oldEvent.Version,
                TransactionId = oldEvent.TransactionId,
                AuthorizationCode = oldEvent.AuthorizationCode,
                Amount = oldEvent.Amount,
                Tip = oldEvent.Tip,
                Provider = oldEvent.Provider,
                OrderId = oldEvent.OrderId,
                IsNoShowFee = oldEvent.IsNoShowFee,
                PromotionUsed = oldEvent.PromotionUsed,
                AmountSavedByPromotion = oldEvent.AmountSavedByPromotion,

                Meter = System.Convert.ToDecimal(fareObject.AmountExclTax),
                Tax = System.Convert.ToDecimal(fareObject.TaxAmount)
            };
        }
    }
}