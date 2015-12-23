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
        public string IdOfInitiator { get; private set; }
        public List<string> IdsOfParticipants { get; private set; }

        public OpenDiscussion(string linkId, string topic, string idOfInitiator, List<string> idsOfParticipants)
        {
            if (String.IsNullOrWhiteSpace(idOfInitiator))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", idOfInitiator));
            if (String.IsNullOrWhiteSpace(linkId))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", linkId));
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", topic));
            if (IdsOfParticipants == null || !IdsOfParticipants.Any())
                throw new ArgumentException(String.Format("{0} cannot be null or empty", IdsOfParticipants));
            LinkId = linkId;
            Topic = topic;
            IdOfInitiator = idOfInitiator;
            IdsOfParticipants = idsOfParticipants;
        }
    }
}