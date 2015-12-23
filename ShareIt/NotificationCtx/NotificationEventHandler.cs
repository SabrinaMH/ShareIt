using ShareIt.DiscussionCtx.Events;
using ShareIt.Infrastructure;
using ShareIt.NotificationCtx.Commands;
using ShareIt.NotificationCtx.Queries;

namespace ShareIt.NotificationCtx
{
    public class NotificationEventHandler
    {
        private readonly Bus _bus;

        public NotificationEventHandler()
        {
            _bus = Bus.Instance;
        }

        public void Handle(DiscussionOpened @event)
        {
            var query = new LinkByIdQuery(@event.LinkId);
            var queryHandler = new NotificationQueryHandler();
            var link = queryHandler.Handle(query);

            var sendNotification = new SendLinkSharedNotification(@event.EmailOfInitiator, @event.EmailsOfParticipants, @event.Topic, @event.DiscussionId, link.Url);
            _bus.Send(sendNotification);
        }
    }
}