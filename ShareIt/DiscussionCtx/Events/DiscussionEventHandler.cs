using System.Collections.Generic;
using ShareIt.DiscussionCtx.Commands;
using ShareIt.Infrastructure;
using ShareIt.LinkCtx.Events;

namespace ShareIt.DiscussionCtx.Events
{
    public class DiscussionEventHandler
    {
        private readonly Bus _bus;

        public DiscussionEventHandler()
        {
            _bus = Bus.Instance;
        }

        public void Handle(SharedLink @event)
        {
            var openDiscussion = new OpenDiscussion(@event.LinkId, @event.Topic, @event.NameOfSharer, @event.EmailOfSharer, @event.EmailsOfReceivers);
            _bus.Send(openDiscussion);
        }

    }
}