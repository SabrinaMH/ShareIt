using System;
using System.Collections.Generic;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Messages
{
    public class ShareLink
    {
        public Link Link { get; private set; }
        public Topic Topic { get; set; }
        public List<Participant> BetweenWho { get; set; }

        public ShareLink(Link link, Topic topic, List<Participant> betweenWho)
        {
            if (link == null) throw new ArgumentNullException("link");
            if (topic == null) throw new ArgumentNullException("topic");
            if (betweenWho == null) throw new ArgumentNullException("betweenWho");

            Link = link;
            Topic = topic;
            BetweenWho = betweenWho;
        } 
    }
}