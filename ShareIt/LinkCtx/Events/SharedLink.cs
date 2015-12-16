using System;
using System.Collections.Generic;
using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Events
{
    public class SharedLink : Event
    {
        public string LinkId { get; private set; }
        public string UriOflink { get; private set; }
        public string NameOfSharer { get; private set; }
        public string EmailOfSharer { get; private set; }
        public string Topic { get; private set; }
        public List<string> EmailsOfReceivers { get; private set; }

        public SharedLink(string linkId, string uriOflink, string nameOfSharer, string emailOfSharer, string topic, List<string> emailsOfReceivers)
        {
            LinkId = linkId;
            UriOflink = uriOflink;
            NameOfSharer = nameOfSharer;
            EmailOfSharer = emailOfSharer;
            Topic = topic;
            EmailsOfReceivers = emailsOfReceivers;
            Id = Guid.NewGuid();
            Version = 0;
        }
    }
}