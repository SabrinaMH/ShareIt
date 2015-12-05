using System;
using System.Collections.Generic;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class DiscussionOpened : Event
    {
        public Guid Id { get; private set; }
        public Topic Topic { get; private set; }
        public List<Participant> BetweenWho { get; private set; }

        public DiscussionOpened(Guid id, Topic topic, List<Participant> betweenWho)
        {
            Id = Guid.NewGuid();
            Id = id;
            Topic = topic;
            BetweenWho = betweenWho;
        }
    }
}