using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class DiscussionId
    {
        public Guid Id { get; private set; }

        public DiscussionId(Guid id)
        {
            Id = id;
        }
    }
}