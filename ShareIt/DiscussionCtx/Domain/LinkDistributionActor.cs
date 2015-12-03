using System;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkDistributionActor : ReceiveActor
    {
        public class StartDiscussionOfLink
        {
            public LinkActor.Discuss Discuss { get; private set; }
            public Link Link { get; private set; }

            public StartDiscussionOfLink(Link link, LinkActor.Discuss discuss)
            {
                if (link == null) throw new ArgumentNullException("link");
                if (discuss == null) throw new ArgumentNullException("discuss");

                Link = link;
                Discuss = discuss;
            }
        }

        public LinkDistributionActor()
        {
            Receive<StartDiscussionOfLink>(msg =>
            {
                var linkActor = Context.Child(msg.Link.ToString());
                if (!linkActor.IsNobody())
                {
                    linkActor.Tell(new LinkActor.Discuss(msg.Discuss.Topic, msg.Discuss.Participants));
                }
            });
        }
         
    }
}