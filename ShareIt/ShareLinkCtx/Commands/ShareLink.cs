using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLink : Command
    {
        public Link Link { get; private set; }
        public SenderId SenderId { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public string Subject { get; private set; }
        public int OriginalVersion { get; private set; }

        public ShareLink(SenderId senderId, Link link, string subject, ListOfReceivers receivers, int originalVersion)
        {
            if (originalVersion < 0) throw new ArgumentException(string.Format("{0} cannot be negative", originalVersion));
            if (link == null) throw new ArgumentNullException("link");
            if (senderId == null) throw new ArgumentNullException("senderId");
            if (receivers == null) throw new ArgumentNullException("receivers");
            if (String.IsNullOrWhiteSpace(subject))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", subject));

            Link = link;
            Subject = subject;
            SenderId = senderId;
            Receivers = receivers;
            OriginalVersion = originalVersion;
        }
    }
}