
using System;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class PostPublished : Event
    {
        public Poster Poster { get; private set; }
        public string BodyText { get; private set; }

        public PostPublished(Poster poster, string bodyText)
        {
            Id = Guid.NewGuid();
            Poster = poster;
            BodyText = bodyText;
        }
    }
}