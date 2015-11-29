using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.ShareLinkCtx.Events
{
    public class SharedLink : Event
    {
        public SharedLink(string id, string nameOfSender, string emailOfSender, List<string> to, string subject,
            string link)
        {
            if (to == null || !to.Any()) throw new ArgumentNullException("to");
            if (String.IsNullOrWhiteSpace(nameOfSender))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", nameOfSender));
            if (String.IsNullOrWhiteSpace(id))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", id));
            if (String.IsNullOrWhiteSpace(subject))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", subject));
            if (String.IsNullOrWhiteSpace(link))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", link));
            if (String.IsNullOrWhiteSpace(emailOfSender))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfSender));

            Id = id;
            NameOfSender = nameOfSender;
            EmailOfSender = emailOfSender;
            To = to;
            Subject = subject;
            Link = link;
        }

        public string Id { get; private set; }
        public string NameOfSender { get; private set; }
        public string EmailOfSender { get; private set; }
        public List<string> To { get; private set; }
        public string Subject { get; private set; }
        public string Link { get; private set; }
    }
}