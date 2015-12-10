using System;
using System.Collections.Generic;
using ShareIt.EventStore;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Link : AggregateRoot
    {
        private readonly Uri _uri;

        public Link(IList<Event> history) : base(history) { }

        public Link(Uri uri)
            : base(new LinkId(uri.OriginalString))
        {
            if (uri == null) throw new ArgumentNullException("uri");
            _uri = uri;
        }

        public override string ToString()
        {
            return _uri.AbsoluteUri;
        }
    }
}