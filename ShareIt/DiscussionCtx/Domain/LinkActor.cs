using System;
using System.Collections.Generic;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkActor : ReceiveActor
    {
        public class Discuss
        {
            public Discuss(Topic topic, List<Participant> participants)
            {
                if (topic == null) throw new ArgumentNullException("topic");
                if (participants == null) throw new ArgumentNullException("participants");
                Topic = topic;
                Participants = participants;
            }

            public List<Participant> Participants { get; private set; }
            public Topic Topic { get; private set; }
        }

        private readonly Uri _uri;

        public LinkActor(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException("uri");
            _uri = uri;

            Initialize();
        }

        private void Initialize()
        {
            Receive<Discuss>(msg =>
            {
                var discussionActor =
                    Context.ActorOf(Props.Create(() => new DiscussionActor(msg.Topic, msg.Participants)));
            });
        }

        public override string ToString()
        {
            return _uri.AbsoluteUri;
        }
    }
}