using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.LinkCtx.Events;

namespace ShareIt.LinkCtx.Domain
{
    public class Link : AggregateRoot
    {
        private Uri _uriOfLink;

        public Link(IList<Event> history) : base(history) { }

        public Link(Uri uri)
            : base(new LinkId(uri.OriginalString))
        {
            if (uri == null) throw new ArgumentNullException("uri");

            ApplyChange(new LinkRegistered(Id, uri.OriginalString));
        }

        public override string ToString()
        {
            return _uriOfLink.OriginalString;
        }

        public void Apply(LinkRegistered @event)
        {
            Id = new LinkId(@event.Id);
            _uriOfLink = new Uri(@event.Uri);
        }

        public void Share(Topic topic, Sharer sharer, ListOfReceivers receivers)
        {
            var emailsOfReceivers = receivers.GetEmails().Select<EmailAddress, string>(x => x).ToList();
            ApplyChange(new SharedLink(Id, this.ToString(), sharer.Name, sharer.Email, topic, emailsOfReceivers));
        }
    }
}