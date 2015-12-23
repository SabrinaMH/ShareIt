using System;
using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Events
{
    public class LinkRegistered : Event
    {
        public string LinkId { get; private set; }
        public string Url { get; private set; }

        public LinkRegistered(string linkId, string url)
        {
            LinkId = linkId;
            Url = url;
            Id = Guid.NewGuid();
        }
    }
}