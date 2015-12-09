using System;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.DiscussionCtx.Messages
{
    public class ShareLink
    {
        public Link Link { get; private set; }
        public Topic Topic { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public Sharer Sharer { get; set; }

        public ShareLink(Link link, Topic topic, Sharer sharer, ListOfReceivers receivers)
        {
            if (link == null) throw new ArgumentNullException("link");
            if (topic == null) throw new ArgumentNullException("topic");
            if (sharer == null) throw new ArgumentNullException("sharer");
            if (receivers == null) throw new ArgumentNullException("receivers");

            Link = link;
            Topic = topic;
            Sharer = sharer;
            Receivers = receivers;
        } 
    }
}