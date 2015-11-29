using System.Collections.Generic;
using Akka.Actor;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Discussion : ReceiveActor
    {
        public Discussion(Topic topic, List<Participant> participants)
        {
        }
    }
}