using System.Net.Mail;
using ShareIt.NotificationCtx.DomainServices;

namespace ShareIt.NotificationCtx.Commands
{
    public class NotificationCommandHandler
    {
        private readonly MailService _mailService;

        public NotificationCommandHandler(MailService mailService)
        {
            _mailService = mailService;
            
        }
        public void Handle(SendLinkSharedNotification sendNotification)
        {
            var mail = new MailMessage();
            string receivers = string.Join(",", sendNotification.EmailsOfParticipants);
            mail.To.Add(receivers);
            mail.From = new MailAddress(sendNotification.EmailOfInitiator);
            mail.Subject = string.Format("{0} shared a link on {1}", sendNotification.EmailOfInitiator, sendNotification.Topic);
            mail.Body = string.Format("Link {0}\\To view the discussion use discussion id {1}", sendNotification.UrlOfLink, sendNotification.DiscussionId);

            _mailService.Send(mail);
        }
    }
}