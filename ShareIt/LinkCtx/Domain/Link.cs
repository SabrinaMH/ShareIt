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
        private Uri _urlOfLink;

        public Link(IList<Event> history) : base(history) { }

        public Link(Uri url)
            : base(new LinkId(url.OriginalString))
        {
            if (url == null) throw new ArgumentNullException("url");

            ApplyChange(new LinkRegistered(Id, url.OriginalString));
        }

        public override string ToString()
        {
            return _urlOfLink.OriginalString;
        }

        public void Apply(LinkRegistered @event)
        {
            Id = new LinkId(@event.LinkId);
            _urlOfLink = new Uri(@event.Url);
        }

        public void Share(Topic topic, Sharer sharer, ListOfReceivers receivers)
        {
            var emailsOfReceivers = receivers.GetEmails().Select<EmailAddress, string>(x => x).ToList();
            ApplyChange(new SharedLink(Id, this.ToString(), sharer.Email, topic, emailsOfReceivers));
        }
    }
}