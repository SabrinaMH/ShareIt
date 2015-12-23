using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.EventStore
{
    public class EventStoreRepository<TAggregate> where TAggregate : AggregateRoot
    {
        private readonly IEventPublisher _bus;
        private const string EventClrTypeHeader = "EventClrTypeName";
        private const string AggregateClrTypeHeader = "AggregateClrTypeName";
        private const string CommitIdHeader = "CommitId";
        private const int ReadPageSize = 200;

        private readonly IEventStoreConnection _connection;

        public EventStoreRepository(IEventPublisher bus)
        {
            if (bus == null) throw new ArgumentNullException("bus");
            _bus = bus;

            var url = ConfigurationManager.AppSettings["eventstore.connection.url"];
            _connection = EventStoreConnection.Create(url);
            _connection.ConnectAsync().Wait();
        }

        public TAggregate GetById(string id) 
        {
            var events = new List<Event>();
            StreamEventsSlice currentSlice;
            var nextSliceStart = StreamPosition.Start;
            var streamName = GetStreamName(typeof(TAggregate), id);

            do
            {
                currentSlice = _connection
                    .ReadStreamEventsForwardAsync(streamName, nextSliceStart, ReadPageSize, false)
                    .Result;
                nextSliceStart = currentSlice.NextEventNumber;
                events.AddRange(currentSlice.Events.Select(x => DeserializeEvent(x)));
            } while (!currentSlice.IsEndOfStream);
            if (!events.Any())
            {
                return null;
            }

            var constructor = typeof(TAggregate).GetConstructor(new Type[] { typeof(IList<Event>) });
            var aggregate = (TAggregate) constructor.Invoke(new object[] { events });
            return aggregate;
        }

        private string GetStreamName(Type type, string id)
        {
            return string.Format("{0}-{1}", type.Name, id);
        }

        private Event DeserializeEvent(ResolvedEvent e) 
        {
            var eventClrTypeName = JObject.Parse(Encoding.UTF8.GetString(e.OriginalEvent.Metadata)).Property(EventClrTypeHeader).Value;
            var eventType = Type.GetType((string)eventClrTypeName);
            var eventData = Encoding.UTF8.GetString(e.OriginalEvent.Data);
            return (Event)JsonConvert.DeserializeObject(eventData, eventType);
        }
        
        public void Save(AggregateRoot aggregate)
        {
            string streamName = GetStreamName(aggregate.GetType(), aggregate.Id);
            List<Event> newEvents = aggregate.GetUncommittedEvents().ToList();
            int originalVersion = aggregate.Version - newEvents.Count;
            int expectedVersion = originalVersion == 0 ? ExpectedVersion.NoStream : originalVersion - 1;
            
            var commitId = Guid.NewGuid();
            var commitHeaders = new Dictionary<string, object>
            {
                {CommitIdHeader, commitId},
                {AggregateClrTypeHeader, aggregate.GetType().AssemblyQualifiedName}
            };
            
            List<EventData> eventsToSave = newEvents.Select(e => ToEventData(Guid.NewGuid(), e, commitHeaders)).ToList();
            _connection.AppendToStreamAsync(streamName, expectedVersion, eventsToSave).Wait();

            foreach (var eventToPublish in newEvents)
            {
                _bus.Publish(eventToPublish);
            }

            aggregate.MarkChangesAsCommitted();
        }

        private static EventData ToEventData(Guid eventId, object evnt, IDictionary<string, object> headers)
        {
            var serializerSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.None};
            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evnt, serializerSettings));

            var eventHeaders = new Dictionary<string, object>(headers)
            {
                {
                    EventClrTypeHeader, evnt.GetType().AssemblyQualifiedName
                }
            };
            byte[] metadata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventHeaders, serializerSettings));
            string typeName = evnt.GetType().Name;

            return new EventData(eventId, typeName, true, data, metadata);
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}