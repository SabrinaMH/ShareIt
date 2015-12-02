using System;
using System.Collections.Generic;
using Akka.Actor;
using Akka.Event;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkActor : ReceiveActor
    {
        public class StartDiscussion
        {
            public Topic Topic { get; private set; }
            public List<Participant> Participants { get; private set; }

            public StartDiscussion(Topic topic, List<Participant> participants)
            {
                if (topic == null) throw new ArgumentNullException("topic");
                if (participants == null) throw new ArgumentNullException("participants");
                Topic = topic;
                Participants = participants;
            }
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
            Receive<StartDiscussion>(discussion =>
            {
                var discussionActor =
                    Context.ActorOf(Props.Create(() => new DiscussionActor(discussion.Topic, discussion.Participants)));
            });
        }

        public override string ToString()
        {
            return _uri.AbsoluteUri;
        }
    }
}