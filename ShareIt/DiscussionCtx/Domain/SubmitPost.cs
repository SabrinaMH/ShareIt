using System;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class SubmitPost : Command
    {
        public DiscussionId DiscussionId { get; private set; }
        public Poster Poster { get; private set; }
        public string BodyText { get; private set; }

        public SubmitPost(DiscussionId id, Poster poster, string bodyText)
        {
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            if (id == null) throw new ArgumentNullException("id");
            if (poster == null) throw new ArgumentNullException("poster");

            DiscussionId = id;
            Poster = poster;
            BodyText = bodyText;
        }
    }
}