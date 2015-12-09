using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Akka.Actor;
using Akka.Event;
using Akka.Logger.Serilog;
using ShareIt.DiscussionCtx.Events;
using ShareIt.DiscussionCtx.Messages;

namespace ShareIt.DiscussionCtx.Domain
{
    public class DiscussionActor : ReceiveActor
    {
        private Guid _id;
        private Topic _topic;
        private List<Participant> _participants;
        private int _numberOfPosts = 0;
        private readonly ILoggingAdapter _log;

        public DiscussionActor(Guid id, Topic topic, List<Participant> participants)
        {
            if (topic == null) throw new ArgumentNullException("topic");
            if (participants == null) throw new ArgumentNullException("participants");
            // Persist(new DiscussionOpened(id, topic, participants), Apply);
            _log = Context.GetLogger(new SerilogLogMessageFormatter());
        }

        private void Apply(DiscussionOpened discussion)
        {
            _id = discussion.Id;
            _topic = discussion.Topic;
            _participants = discussion.BetweenWho;
        }

    //    protected override void Receive<PublishPost>(msg =>
    //{
        
    //            //var post = message as PublishPost;
    //            //Persist(new PostPublished(post.Poster, post.BodyText), Apply);
    //}
    //);

        private void Apply(PostPublished post)
        {
            var postNumber = _numberOfPosts;
            Context.ActorOf(Props.Create(() => new PostActor(post.Poster, post.BodyText, postNumber)));
            _numberOfPosts++;
        }
    }
}