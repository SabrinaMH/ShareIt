using System;
using Akka.Actor;
using ShareIt.DiscussionCtx.Messages;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkCoordinatorActor : ReceiveActor
    {
        public LinkCoordinatorActor()
        {
            Receive<ShareLink>(msg =>
            {
                var link = msg.Link.ToString();
                var linkActor = Context.Child(link);
                if (linkActor.IsNobody())
                {
                    linkActor = Context.ActorOf(Props.Create(() => new LinkActor(new Uri(link))), link);
                }
                linkActor.Tell(new OpenDiscussion(msg.Topic, msg.BetweenWho));
            });

            Receive<SubmitPost>(msg =>
            {
                // Use this route, if we say that SubmitPost shouldn't know about the link (would make sense UI wise). 
                // This requires that DiscussionId is unique throughout the system.
                // Alternatively, we need SubmitPost to carry along a LinkId.
                var discussionActor = Actors.System.ActorSelection(string.Format("/user/linkCoordinator/*/{0}", msg.DiscussionId));
                discussionActor.Tell(new PublishPost(msg.BodyText, msg.Poster));
            });
        }
    }
}