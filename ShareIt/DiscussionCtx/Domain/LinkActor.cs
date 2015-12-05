using System;
using System.Collections.Generic;
using Akka.Actor;
using Akka.Persistence;
using ShareIt.DiscussionCtx.Events;
using ShareIt.DiscussionCtx.Messages;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkActor : PersistentActor
    {
        private readonly Uri _uri;

        public LinkActor(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException("uri");
            _uri = uri;
        }

        public string Id
        {
            get { return _uri.AbsoluteUri; }
        }

        protected override bool ReceiveRecover(object message)
        {
            throw new NotImplementedException();
        }

        protected override bool ReceiveCommand(object message)
        {
            if (message is OpenDiscussion)
            {
                var discussion = message as OpenDiscussion;
                var discussionId = Guid.NewGuid();
                Persist(new DiscussionOpened(discussionId, discussion.Topic, discussion.BetweenWho), Apply);
            }
            else
            {
                return false;
            }
            return true;
        }

        private void Apply(DiscussionOpened discussion)
        {
            var discussionActor = Context.Child(discussion.Id.ToString());
            if (discussionActor.IsNobody())
            {
                discussionActor =
                    Context.ActorOf(
                        Props.Create(() => new DiscussionActor(discussion.Id, discussion.Topic, discussion.BetweenWho)),
                        discussion.Id.ToString());
            }
        }

        public override string PersistenceId
        {
            get { return Id; }
        }
    }
}