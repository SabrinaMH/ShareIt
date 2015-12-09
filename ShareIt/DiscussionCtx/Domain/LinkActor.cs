using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using Akka.Actor;
using Akka.Event;
using ShareIt.DiscussionCtx.Events;
using ShareIt.DiscussionCtx.Messages;
using ShareIt.EventStore;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkActor : AggregateRoot
    {
        private Uri _uri;
        private Sharer _sharer;

        public LinkActor(IList<Event> history) : base(history) { }

        public LinkActor(Uri uri, Sharer sharer) : base(new Identity())
        {
            if (uri == null) throw new ArgumentNullException("uri");
            if (sharer == null) throw new ArgumentNullException("sharer");

            ApplyChange(new LinkActorCreated(Id, uri.OriginalString, sharer.Email, sharer.Name));

            Receive<OpenDiscussion>(msg =>
            {
                Logger.Debug("LinkActor received OpenDiscussion message");
            });
        }

        private void Apply(LinkActorCreated @event)
        {
            Id = new Identity(@event.Id);
            _uri = new Uri(@event.Uri);
            _sharer = new Sharer(new Name(@event.Name), new EmailAddress(@event.Email));
        }



    //    protected void Receive<OpenDiscussion>(msg =>
    //{
    //    _log.Debug("in handle opendiscussion of LinkActor");

    //    //var discussion = message as OpenDiscussion;
    //    //var discussionId = Guid.NewGuid();
    //    return true;
    //}
    //);

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
    }
}