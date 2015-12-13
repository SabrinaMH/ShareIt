using System.Net.Mail;
using ShareIt.DiscussionCtx.Events;
using ShareIt.LinkCtx.Events;
using ShareIt.NotificationCtx.DomainServices;

namespace ShareIt.NotificationCtx
{
    public class NotificationEventHandler
    {
        private readonly MailService _mailService;

        public NotificationEventHandler(MailService mailService)
        {
            _mailService = mailService;
        }

        public void Handle(DiscussionOpened @event)
        {
            var mail = new MailMessage();
            string receivers = string.Join(",", @event.EmailsOfTheOtherParticipants);
            mail.To.Add(receivers);
            mail.From = new MailAddress(@event.EmailOfInitiator);
            mail.Subject = string.Format("{0} shared a link on {1}", @event.NameOfInitiator, @event.Topic);
            mail.Body = string.Format("To view the link use link id {0}\\To join the discussion use discussion id {1}", @event.LinkId, @event.DiscussionId);

            _mailService.Send(mail);
        }
    }
}