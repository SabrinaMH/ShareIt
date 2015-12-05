using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkId
    {
        public Guid Id { get; private set; }

        public LinkId(Guid id)
        {
            Id = id;
        }
    }
}