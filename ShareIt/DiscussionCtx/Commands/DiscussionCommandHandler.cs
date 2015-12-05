using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Commands
{
    public class DiscussionCommandHandler
    {
        public void Handle(SubmitPost submitPost)
        {
            Actors.LinkCoordinator.Tell(submitPost);
        }
    }
}