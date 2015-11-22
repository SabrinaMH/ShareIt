using System.Collections.Generic;
using System.Web.DynamicData;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.EventStore
{
    public class Repository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public T ById(Identity id)
        {
            var aggregate = new T();
            List<Event> eventStream = _storage.GetEventsForAggregate(id.Value);
            aggregate.LoadFromHistory(eventStream);
            return aggregate;
        }

        public void Save(T aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }
    }
}