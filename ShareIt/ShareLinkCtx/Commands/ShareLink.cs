using System;
using System.Security.Cryptography.X509Certificates;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLink : Command
    {
        public ShareLink(EmailAddress emailOfSharer, Name nameOfSharer, string subject, Link link, ListOfReceivers receivers)
        {
            if (emailOfSharer == null) throw new ArgumentNullException("emailOfSharer");
            if (nameOfSharer == null) throw new ArgumentNullException("nameOfSharer");
            if (link == null) throw new ArgumentNullException("link");
            if (receivers == null) throw new ArgumentNullException("receivers");
            if (String.IsNullOrWhiteSpace(subject))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", subject));

            EmailOfSharer = emailOfSharer;
            NameOfSharer = nameOfSharer;
            Link = link;
            Subject = subject;
            Receivers = receivers;
        }

        public EmailAddress EmailOfSharer { get; set; }
        public Name NameOfSharer { get; set; }
        public Link Link { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public string Subject { get; private set; }
        public int OriginalVersion { get; private set; }
    }
}