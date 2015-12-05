using System;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Akka.Actor;
using Akka.Persistence;
using ShareIt.DiscussionCtx.Events;
using ShareIt.DiscussionCtx.Messages;

namespace ShareIt.DiscussionCtx.Domain
{
    public class DiscussionActor : PersistentActor
    {
        private Guid _id;
        private Topic _topic;
        private List<Participant> _participants;
        private int _numberOfPosts = 0;

        public DiscussionActor(Guid id, Topic topic, List<Participant> participants)
        {
            if (topic == null) throw new ArgumentNullException("topic");
            if (participants == null) throw new ArgumentNullException("participants");
            Persist(new DiscussionOpened(id, topic, participants), Apply);
        }

        private void Apply(DiscussionOpened discussion)
        {
            _id = discussion.Id;
            _topic = discussion.Topic;
            _participants = discussion.BetweenWho;
        }

        protected override bool ReceiveRecover(object message)
        {
            throw new NotImplementedException();
        }

        protected override bool ReceiveCommand(object message)
        {
            if (message is PublishPost)
            {
                var post = message as PublishPost;
                Persist(new PostPublished(post.Poster, post.BodyText), Apply);
            }
            else
            {
                return false;
            }
            return true;
        }

        private void Apply(PostPublished post)
        {
            var postNumber = _numberOfPosts;
            Context.ActorOf(Props.Create(() => new PostActor(post.Poster, post.BodyText, postNumber)));
            _numberOfPosts++;
        }

        public override string PersistenceId
        {
            get { return _id.ToString(); }
        }
    }
}