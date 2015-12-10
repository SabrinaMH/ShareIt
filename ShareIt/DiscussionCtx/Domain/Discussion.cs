using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using ShareIt.DiscussionCtx.Events;
using ShareIt.EventStore;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Discussion : AggregateRoot
    {
        private Guid _id;
        private Topic _topic;
        private List<Participant> _participants;
        private int _numberOfPosts = 0;

        public Discussion(IList<Event> history) : base(history) { }

        public Discussion(Guid id, Topic topic, List<Participant> participants)
            : base(new DiscussionId(id))
        {
            if (topic == null) throw new ArgumentNullException("topic");
            if (participants == null) throw new ArgumentNullException("participants");

            ApplyChange(new DiscussionOpened(id, topic, participants));
        }

        private void Apply(DiscussionOpened discussion)
        {
            _id = discussion.Id;
            _topic = discussion.Topic;
            _participants = discussion.BetweenWho;
        }

        private void Apply(PostPublished post)
        {
            _numberOfPosts++;
        }
    }
}