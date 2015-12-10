using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.DiscussionCtx.Events;
using ShareIt.EventStore;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Sharer : AggregateRoot
    {
        private Name _name;
        private EmailAddress _email;

        public Sharer(IList<Event> history) : base(history) { }

        public Sharer(Name name, EmailAddress email) : base(new SharerId(email))
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");

            ApplyChange(new SharerRegistered((SharerId)Id, name, email));
        }

        private void Apply(SharerRegistered @event)
        {
            Id = @event.Id;
            _name = @event.Name;
            _email = @event.Email;
        }
    }
}