using System;
using System.Linq;
using Akka.Actor;
using Akka.Event;
using Akka.Logger.Serilog;
using ShareIt.DiscussionCtx.Messages;
using ShareIt.EventStore;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkCoordinatorActor : ReceiveActor
    {
        private readonly EventStoreRepository<LinkActor> _repository;
        private readonly ILoggingAdapter _log;

        public LinkCoordinatorActor(EventStoreRepository<LinkActor> repository)
        {
            _repository = repository;
            _log = Context.GetLogger(new SerilogLogMessageFormatter());

            Receive<ShareLink>(msg =>
            {
                var actorName = ConvertLinkToActorName(msg.Link);
                var linkActor = Context.Child(actorName);
                if (linkActor.IsNobody())
                {
                    var uri = new Uri(msg.Link.ToString());
                    linkActor = Context.ActorOf(Props.Create(() => new LinkActor(uri, msg.Sharer)), actorName);
                }
                var participants = msg.Receivers.GetEmails().Select(email => new Participant(email)).ToList();
                participants.Add(new Participant(msg.Sharer.Email));
                linkActor.Tell(new OpenDiscussion(msg.Topic, participants));
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

        // Actor name cannot contain /
        private string ConvertLinkToActorName(Link link)
        {
            return link.ToString().Replace('/', '-');
        }
    }
}