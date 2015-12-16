using System.Collections.Generic;

namespace ShareIt.ReadCtx.Models
{
    public class Discussion
    {
        public string Topic { get; set; }
        public Participant Initiator { get; set; }
        public List<Participant> TheOtherParticipants { get; set; }
        public string LinkId { get; set; }
        public List<Post> Posts { get; set; }

        public Discussion(string topic, Participant initiator, List<Participant> theOtherParticipants, string linkId)
        {
            Topic = topic;
            Initiator = initiator;
            TheOtherParticipants = theOtherParticipants;
            LinkId = linkId;
            Posts = new List<Post>();
        }
    }
}