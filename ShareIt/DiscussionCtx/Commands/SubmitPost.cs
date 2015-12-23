using System;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Commands
{
    public class SubmitPost : Command
    {
        public Guid DiscussionId { get; private set; }
        public string EmailOfPoster { get; private set; }
        public string BodyText { get; private set; }

        public SubmitPost(Guid discussionId, string emailOfPoster, string bodyText)
        {
            if (String.IsNullOrWhiteSpace(emailOfPoster))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfPoster));
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            
            DiscussionId = discussionId;
            EmailOfPoster = emailOfPoster;
            BodyText = bodyText;
        }
    }
}