using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Link
    {
        private readonly Uri _uri;

        public Link(Uri uri)
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