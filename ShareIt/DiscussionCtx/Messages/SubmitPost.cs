using System;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Messages
{
    public class SubmitPost
    {
        public Poster Poster { get; private set; }
        public string BodyText { get; private set; }

        public SubmitPost(Poster poster, string bodyText)
        {
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            if (poster == null) throw new ArgumentNullException("poster");
            Poster = poster;
            BodyText = bodyText;
        } 
    }
}