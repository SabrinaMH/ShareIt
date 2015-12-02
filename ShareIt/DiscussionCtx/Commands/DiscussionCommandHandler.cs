using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Commands
{
    public class DiscussionCommandHandler
    {
        public void Handle(SubmitPost submitPost)
        {
            var discussionActor = Actors.System.ActorSelection(string.Format("/user/**/{0}", submitPost.DiscussionId));
            discussionActor.Tell(new DiscussionActor.SubmitPost(submitPost.Poster, submitPost.BodyText));
        }
    }
}