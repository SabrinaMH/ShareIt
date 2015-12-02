using System.Net.Mail;
using ShareIt.NotificationCtx.DomainServices;
using ShareIt.ShareLinkCtx.Events;

namespace ShareIt.NotificationCtx
{
    public class NotificationEventHandlers
    {
        private readonly MailService _mailService;

        public NotificationEventHandlers(MailService mailService)
        {
            _mailService = mailService;
        }

        public void Handle(SharedLink @event)
        {
            var mail = new MailMessage();
            string receivers = string.Join(",", @event.To);
            mail.To.Add(receivers);
            mail.From = new MailAddress(@event.EmailOfSharer);
            mail.Subject = string.Format("{0} shared a link on {1} with you", @event.NameOfSharer, @event.Subject);
            mail.Body = "To view the link go to ...";

            _mailService.Send(mail);
        }
    }
}