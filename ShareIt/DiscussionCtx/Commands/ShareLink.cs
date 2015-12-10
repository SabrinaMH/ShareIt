using System;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Commands
{
    public class ShareLink : Command
    {
        public Link Link { get; private set; }
        public Topic Topic { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public Name NameOfSharer { get; set; }
        public EmailAddress EmailOfSharer { get; set; }

        public ShareLink(Link link, Topic topic, EmailAddress emailOfSharer, Name nameOfSharer, ListOfReceivers receivers)
        {
            if (link == null) throw new ArgumentNullException("link");
            if (topic == null) throw new ArgumentNullException("topic");
            if (emailOfSharer == null) throw new ArgumentNullException("emailOfSharer");
            if (nameOfSharer == null) throw new ArgumentNullException("nameOfSharer");
            if (receivers == null) throw new ArgumentNullException("receivers");

            Link = link;
            Topic = topic;
            NameOfSharer = nameOfSharer;
            EmailOfSharer = emailOfSharer;
            Receivers = receivers;
        } 
    }
}