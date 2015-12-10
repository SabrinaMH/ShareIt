using System;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Commands
{
    public class PublishPost
    {
        public string BodyText { get; private set; }
        public Poster Poster { get; private set; }

        public PublishPost(string bodyText, Poster poster)
        {
            if (poster == null) throw new ArgumentNullException("poster");
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            BodyText = bodyText;
            Poster = poster;
        }
    }
}