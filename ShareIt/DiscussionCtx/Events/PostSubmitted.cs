using System;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class PostSubmitted : Event
    {
        public string DiscussionId { get; private set; }
        public string NameOfPoster { get; private set; }
        public string EmailAddressOfPoster { get; private set; }
        public string BodyText { get; private set; }

        public PostSubmitted(string discussionId, string nameOfPoster, string emailAddressOfPoster, string bodyText)
        {
            DiscussionId = discussionId;
            NameOfPoster = nameOfPoster;
            EmailAddressOfPoster = emailAddressOfPoster;
            BodyText = bodyText;
            Id = Guid.NewGuid();
        }
    }
}