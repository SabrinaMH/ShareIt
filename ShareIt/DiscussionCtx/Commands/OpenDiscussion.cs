using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Commands
{
    public class OpenDiscussion : Command
    {
        public string LinkId { get; private set; }
        public string Topic { get; private set; }
        public string NameOfInitiator { get; private set; }
        public string EmailOfInitiator { get; private set; }
        public List<string> EmailsOfParticipants { get; private set; }

        public OpenDiscussion(string linkId, string topic, string nameOfInitiator, string emailOfInitiator, List<string> emailsOfParticipants)
        {
            if (String.IsNullOrWhiteSpace(nameOfInitiator))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", nameOfInitiator));
            if (String.IsNullOrWhiteSpace(emailOfInitiator))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", emailOfInitiator));
            if (String.IsNullOrWhiteSpace(linkId))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", linkId));
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", topic));
            if (emailsOfParticipants == null || !emailsOfParticipants.Any())
                throw new ArgumentException(String.Format("{0} cannot be null or empty", emailsOfParticipants));
            LinkId = linkId;
            Topic = topic;
            NameOfInitiator = nameOfInitiator;
            EmailOfInitiator = emailOfInitiator;
            EmailsOfParticipants = emailsOfParticipants;
        }
    }
}