using System;
using System.Security.Cryptography.X509Certificates;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLink : Command
    {
        public ShareLink(EmailAddress emailOfSender, Name nameOfSender, string subject, Link link, ListOfReceivers receivers)
        {
            if (emailOfSender == null) throw new ArgumentNullException("emailOfSender");
            if (nameOfSender == null) throw new ArgumentNullException("nameOfSender");
            if (link == null) throw new ArgumentNullException("link");
            if (receivers == null) throw new ArgumentNullException("receivers");
            if (String.IsNullOrWhiteSpace(subject))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", subject));

            EmailOfSender = emailOfSender;
            NameOfSender = nameOfSender;
            Link = link;
            Subject = subject;
            Receivers = receivers;
        }

        public EmailAddress EmailOfSender { get; set; }
        public Name NameOfSender { get; set; }
        public Link Link { get; private set; }
        public ListOfReceivers Receivers { get; private set; }
        public string Subject { get; private set; }
        public int OriginalVersion { get; private set; }
    }
}