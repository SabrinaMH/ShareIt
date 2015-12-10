using System;
using System.Collections.Generic;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Commands
{
    public class OpenDiscussion 
    {
        public Topic Topic { get; private set; }
        public List<Participant> BetweenWho { get; private set; }

        public OpenDiscussion(Topic topic, List<Participant> betweenWho)
        {
            if (topic == null) throw new ArgumentNullException("topic");
            if (betweenWho == null) throw new ArgumentNullException("betweenWho");
            Topic = topic;
            BetweenWho = betweenWho;
        }
    }
}