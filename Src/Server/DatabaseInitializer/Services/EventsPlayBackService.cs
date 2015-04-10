#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.EventSourcing;
using Infrastructure.Messaging;
using Infrastructure.Serialization;
using Infrastructure.Sql.EventSourcing;
using ServiceStack.Text;
using System.Diagnostics;

#endregion

namespace DatabaseInitializer.Services
{
    public class EventsPlayBackService : IEventsPlayBackService
    {
        private readonly Func<EventStoreDbContext> _contextFactory;
        private readonly IEventBus _eventBus;
        private readonly ITextSerializer _serializer;

        public EventsPlayBackService(Func<EventStoreDbContext> contextFactory, IEventBus eventBus,
            ITextSerializer serializer)
        {
            _contextFactory = contextFactory;
            _eventBus = eventBus;
            _serializer = serializer;
        }

        public int CountEvent(string aggregateType)
        {
            using (var context = _contextFactory.Invoke())
            {
                return context.Set<Event>().Count(ev => ev.AggregateType == aggregateType);
            }
        }

        public class CallStats
        {
            public long Count { get; set; }
            public long TotalTime { get; set; }

            public long LastTime { get; set; }
        }

        public void ReplayAllEvents(DateTime? after = null)
        {
            var skip = 0;
            var hasMore = true;
            const int pageSize = 100000;
            after = after ?? DateTime.MinValue;

            var stats = new Dictionary<string, CallStats>();

            Console.WriteLine("Replaying event since {0}", after);

            while(hasMore)
            {
                List<Event> events;

                Console.WriteLine("Getting next events...");
                using (var context = _contextFactory.Invoke())
                {
                    context.Database.CommandTimeout = 0;
                    // order by date then by version in case two events happened at the same time
                    events = context.Set<Event>()
                                    .OrderBy(x => x.EventDate)
                                    .ThenBy(x => x.Version)
                                    .Where(x => x.EventDate > after)
                                    .Skip(skip)
                                    .Take(pageSize)
                                    .ToList();
                }

                Console.WriteLine("Done getting next events...");

                if (events.Count == 0)
                {
                    Console.WriteLine("No event to be replayed");
                    return;
                }
                
                hasMore = events.Count == pageSize;
                Console.WriteLine("Number of events played: " + (hasMore ? skip : (skip + events.Count)));
                skip += pageSize;



                var sw = Stopwatch.StartNew();
                long start = 0;
                long end = sw.ElapsedMilliseconds;


                if (events.Any())
                {
                    int eCount = 0;
                    foreach (var @event in events)
                    {
                        try
                        {
                            var ev = Deserialize(@event);

                            _eventBus.Publish(new Envelope<IEvent>(ev)
                            {
                                CorrelationId = @event.CorrelationId
                            });

                            start = end;
                            end = sw.ElapsedMilliseconds;
                            

                            if ( !stats.ContainsKey(ev.GetType().FullName ))
                            {
                                stats.Add(ev.GetType().FullName, new CallStats());
                            }
                            stats[ev.GetType().FullName].Count++;
                            stats[ev.GetType().FullName].TotalTime += end - start;
                            stats[ev.GetType().FullName].LastTime = end - start;

                            

                            eCount++;

                            if ( eCount % 5000 == 0)
                            {
                                PrintStats(stats);
                            }
                            
                            start = end;
                            end = sw.ElapsedMilliseconds;

                            //Console.Write("Playing event : " + eCount);
                        }
                        catch
                        {
                            Console.Write("Error replaying an event : ");
                            if (@event != null)
                            {                                
                                Console.Write(@event.ToJson());
                            }
                            throw;
                        }
                    }
                }
                
            }
            
        }

        private void PrintStats(Dictionary<string, CallStats> stats)
        {
            Console.WriteLine("*****Printing stats*****");
            foreach (var key in stats.Keys)
            {
                Console.WriteLine(string.Format("For event {0}, average excecution {1}ms, last call : {2}ms, total count : {3} ", key, stats[key].TotalTime / stats[key].Count, stats[key].LastTime, stats[key].Count));
            }
            Console.WriteLine("************************");
        }

        private IVersionedEvent Deserialize(Event @event)
        {
            using (var reader = new StringReader(@event.Payload))
            {
                var e = (IVersionedEvent) _serializer.Deserialize(reader);
                if (e is IUpgradableEvent)
                {
                    e = ((IUpgradableEvent) e).Upgrade();
                }
                return e;
            }
        }
    }
}