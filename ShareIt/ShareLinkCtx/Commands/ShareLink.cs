using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLink
    {
        public Link Link { get; private set; }
        public Sender Sender { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public string Subject { get; private set; }

        public ShareLink(Link link, string subject, Sender sender, ListOfReceivers receivers)
        {
            if (link == null) throw new ArgumentNullException("link");
            if (sender == null) throw new ArgumentNullException("sender");
            if (receivers == null) throw new ArgumentNullException("receivers");
            if (String.IsNullOrWhiteSpace(subject))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", subject));

            Link = link;
            Subject = subject;
            Sender = sender;
            Receivers = receivers;
        }
    }
}