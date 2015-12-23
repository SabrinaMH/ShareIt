using System;
using System.Collections.Generic;
using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Events
{
    public class SharedLink : Event
    {
        public string LinkId { get; private set; }
        public string UrlOflink { get; private set; }
        public string EmailOfSharer { get; private set; }
        public string Topic { get; private set; }
        public List<string> EmailsOfReceivers { get; private set; }

        public SharedLink(string linkId, string urlOflink, string emailOfSharer, string topic, List<string> emailsOfReceivers)
        {
            LinkId = linkId;
            UrlOflink = urlOflink;
            EmailOfSharer = emailOfSharer;
            Topic = topic;
            EmailsOfReceivers = emailsOfReceivers;
            Id = Guid.NewGuid();
        }
    }
}