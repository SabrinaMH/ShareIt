using System;
using System.Collections.Generic;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class DiscussionOpened : Event
    {
        public Guid DiscussionId { get; private set; }
        public string LinkId { get; private set; }
        public string Topic { get; private set; }
        public string NameOfInitiator { get; private set; }
        public string EmailOfInitiator { get; private set; }
        public List<string> EmailsOfTheOtherParticipants { get; private set; }

        public DiscussionOpened(Guid discussionId, string linkId, string topic, string nameOfInitiator, string emailOfInitiator, List<string> emailsOfTheOtherParticipants)
        {
            DiscussionId = discussionId;
            LinkId = linkId;
            Topic = topic;
            NameOfInitiator = nameOfInitiator;
            EmailOfInitiator = emailOfInitiator;
            EmailsOfTheOtherParticipants = emailsOfTheOtherParticipants;
        }
    }
}