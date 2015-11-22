using System;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Events
{
    public class LinkShared : Event
    {
        public Guid Id { get; private set; }

        public LinkShared(Guid id)
        {
            Id = id;
        }
    }
}