using System;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Messages
{
    public class SubmitPost
    {
        public LinkId LinkId { get; private set; }
        public DiscussionId DiscussionId { get; private set; }
        public Poster Poster { get; private set; }
        public string BodyText { get; private set; }

        public SubmitPost(LinkId linkId, DiscussionId discussionId, Poster poster, string bodyText)
        {
            if (linkId == null) throw new ArgumentNullException("linkId");
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            if (discussionId == null) throw new ArgumentNullException("id");
            if (poster == null) throw new ArgumentNullException("poster");

            LinkId = linkId;
            DiscussionId = discussionId;
            Poster = poster;
            BodyText = bodyText;
        }
    }
}