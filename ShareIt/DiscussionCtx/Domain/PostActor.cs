using System;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Domain
{
    public class PostActor : ReceiveActor
    {
        public Poster Poster { get; private set; }
        public string BodyText { get; private set; }
        public int PostNumber { get; private set; }

        public PostActor(Poster poster, string bodyText, int postNumber)
        {
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            if (postNumber < 0) throw new ArgumentException(string.Format("{0} cannot be negative", postNumber));
            if (poster == null) throw new ArgumentNullException("poster");

            Poster = poster;
            BodyText = bodyText;
            PostNumber = postNumber;
        }
    }
}