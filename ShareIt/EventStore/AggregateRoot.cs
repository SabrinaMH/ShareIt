using System;
using System.Collections;
using System.Collections.Generic;
using ShareIt.Infrastructure;

namespace ShareIt.EventStore
{
    public abstract class AggregateRoot
    {
        private readonly IList<Event> _changes = new List<Event>();
        public abstract Guid Id { get; }

        public IList<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void LoadFromHistory(IList<Event> history)
        {
            foreach (var @event in history)
            {
                ApplyChange(@event, false);
            }
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew) _changes.Add(@event);
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }
    }
}