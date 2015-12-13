using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Commands
{
    public class ShareLink : Command
    {
        public string Link { get; private set; }
        public string Topic { get; private set; }
        public List<string> EmailsOfReceivers { get; private set; }
        public string NameOfSharer { get; set; }
        public string EmailOfSharer { get; set; }

        public ShareLink(string link, string topic, string emailOfSharer, string nameOfSharer, List<string> emailsOfReceivers)
        {
            if (String.IsNullOrWhiteSpace(link))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", link));
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", topic));
            if (String.IsNullOrWhiteSpace(emailOfSharer))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfSharer));
            if (String.IsNullOrWhiteSpace(nameOfSharer))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", nameOfSharer));
            if (emailsOfReceivers == null || !emailsOfReceivers.Any())
                throw new ArgumentException(String.Format("{0} cannot be null or empty", emailsOfReceivers));

            Link = link;
            Topic = topic;
            NameOfSharer = nameOfSharer;
            EmailOfSharer = emailOfSharer;
            EmailsOfReceivers = emailsOfReceivers;
        } 
    }
}