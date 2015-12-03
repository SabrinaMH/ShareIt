using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Events;

namespace ShareIt.DiscussionCtx.Events
{
    public class DiscussionEventHandlers
    {
        public void Handle(SharedLink @event)
        {
            var link = new Link(new Uri(@event.Link));
            var topic = new Topic(@event.Subject);
            var participants = new List<Participant>();
            participants.AddRange(@event.To.Select(x => new Participant(new EmailAddress(x))));
            participants.Add(new Participant(new EmailAddress(@event.EmailOfSharer)));

            var discuss = new LinkActor.Discuss(topic, participants);
            Actors.DistributionActor.Tell(new LinkDistributionActor.StartDiscussionOfLink(link, discuss));
        }
    }
}