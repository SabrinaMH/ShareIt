using System;
using System.Collections.Generic;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.SharerCtx.Events;

namespace ShareIt.SharerCtx.Domain
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

            ApplyChange(new SharerRegistered(Id, name, email));
        }

        private void Apply(SharerRegistered @event)
        {
            Id = new SharerId(@event.Id);
            _name = new Name(@event.Name);
            _email = new EmailAddress(@event.Email);
        }
    }
}