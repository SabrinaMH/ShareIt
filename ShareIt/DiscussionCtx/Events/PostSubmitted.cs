using System;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class PostSubmitted : Event
    {
        public string DiscussionId { get; private set; }
        public string EmailAddressOfPoster { get; private set; }
        public string BodyText { get; private set; }
        public int PostNumber { get; private set; }

        public PostSubmitted(string discussionId, string emailAddressOfPoster, string bodyText, int postNumber)
        {
            DiscussionId = discussionId;
            EmailAddressOfPoster = emailAddressOfPoster;
            BodyText = bodyText;
            PostNumber = postNumber;
            Id = Guid.NewGuid();
        }
    }
}