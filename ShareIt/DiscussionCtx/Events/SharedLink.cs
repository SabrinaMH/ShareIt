using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class SharedLink : Event
    {
        public SharedLink(string sharerId, string nameOfSharer, string emailOfSharer, List<string> to, string topic,
            string link)
        {
            if (to == null || !to.Any()) throw new ArgumentNullException("to");
            if (String.IsNullOrWhiteSpace(nameOfSharer))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", nameOfSharer));
            if (String.IsNullOrWhiteSpace(sharerId))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", sharerId));
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", topic));
            if (String.IsNullOrWhiteSpace(link))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", link));
            if (String.IsNullOrWhiteSpace(emailOfSharer))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfSharer));

            SharerId = sharerId;
            NameOfSharer = nameOfSharer;
            EmailOfSharer = emailOfSharer;
            To = to;
            Topic = topic;
            Link = link;
        }

        public string SharerId { get; private set; }
        public string NameOfSharer { get; private set; }
        public string EmailOfSharer { get; private set; }
        public List<string> To { get; private set; }
        public string Topic { get; private set; }
        public string Link { get; private set; }
    }
}