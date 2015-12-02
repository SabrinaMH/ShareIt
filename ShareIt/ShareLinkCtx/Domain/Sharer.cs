using System;
using System.Collections.Generic;
using System.Linq;
using Akka.IO;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Events;

namespace ShareIt.ShareLinkCtx.Domain
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

        public void ShareLink(ListOfReceivers receivers, string subject, Link link)
        {
            if (receivers == null) throw new ArgumentNullException("receivers");
            if (link == null) throw new ArgumentNullException("link");

            List<string> emailsOfReceivers = receivers.GetEmails().Select(x => x.Value).ToList();
            ApplyChange(new SharedLink(Id, _name, _email, emailsOfReceivers, subject, link.ToString()));
        }

        private void Apply(SharerRegistered @event)
        {
            Id = @event.Id;
            _name = @event.Name;
            _email = @event.Email;
        }
    }
}