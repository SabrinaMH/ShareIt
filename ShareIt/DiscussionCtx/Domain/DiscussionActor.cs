using System;
using System.Collections.Generic;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Domain
{
    public class DiscussionActor : ReceiveActor
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

        private Topic _topic;
        private List<Participant> _participants;
        private int _nextPostNumber = 0;

        public DiscussionActor(Topic topic, List<Participant> participants)
        {
            if (topic == null) throw new ArgumentNullException("topic");
            if (participants == null) throw new ArgumentNullException("participants");
            _topic = topic;
            _participants = participants;

            Initialize();
        }

        private void Initialize()
        {
            Receive<SubmitPost>(post =>
            {
                Context.ActorOf(Props.Create(() => new PostActor(post.Poster, post.BodyText, _nextPostNumber)));
                _nextPostNumber++;
            });
        }
    }
}