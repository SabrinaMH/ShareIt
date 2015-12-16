using System;
using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Events
{
    public class LinkRegistered : Event
    {
        public string LinkId { get; private set; }
        public string Uri { get; private set; }

        public LinkRegistered(string linkId, string uri)
        {
            LinkId = linkId;
            Uri = uri;
            Id = Guid.NewGuid();
            Version = 0;
        }
    }
}