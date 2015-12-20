using System;
using System.Collections.Generic;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.UserCtx.Events;

namespace ShareIt.UserCtx.Domain
{
    public class User : AggregateRoot
    {
        private Name _name;
        private EmailAddress _email;

        public User(IList<Event> history) : base(history) { }

        public User(Name name, EmailAddress email) : base(new UserId(email))
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");

            ApplyChange(new UserRegistered(Id, name, email));
        }

        private void Apply(UserRegistered @event)
        {
            Id = new UserId(@event.UserId);
            _name = new Name(@event.Name);
            _email = new EmailAddress(@event.Email);
        }
    }
}