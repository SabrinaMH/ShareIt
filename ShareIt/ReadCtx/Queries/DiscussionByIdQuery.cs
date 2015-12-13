﻿using System;

namespace ShareIt.ReadCtx.Queries
{
    public class DiscussionByIdQuery
    {
        public Guid DiscussionId { get; private set; }

        public DiscussionByIdQuery(Guid discussionId)
        {
            DiscussionId = discussionId;
        }
    }
}