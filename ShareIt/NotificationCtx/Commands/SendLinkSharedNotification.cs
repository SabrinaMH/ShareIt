using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.NotificationCtx.Commands
{
    public class SendLinkSharedNotification : Command
    {
        public string EmailOfInitiator { get; private set; }
        public List<string> EmailsOfParticipants { get; private set; }
        public string Topic { get; private set; }
        public Guid DiscussionId { get; private set; }
        public string UrlOfLink { get; set; }

        public SendLinkSharedNotification(string emailOfInitiator, List<string> emailsOfParticipants, string topic, Guid discussionId, string urlOfLink)
        {
            if (String.IsNullOrWhiteSpace(emailOfInitiator))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfInitiator));
            if (emailsOfParticipants == null || !emailsOfParticipants.Any()) throw new ArgumentException(String.Format("{0} cannot be null or empty", emailsOfParticipants));
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", topic));
            if (String.IsNullOrWhiteSpace(urlOfLink))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", urlOfLink));
            

            EmailOfInitiator = emailOfInitiator;
            EmailsOfParticipants = emailsOfParticipants;
            Topic = topic;
            DiscussionId = discussionId;
            UrlOfLink = urlOfLink;
        }
    }
}