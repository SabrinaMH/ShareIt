using System;
using System.Net.Mail;
using ShareIt.NotificationCtx.Domain;

namespace ShareIt.NotificationCtx.Commands
{
    public class SendNotificationCommandHandler
    {
        private readonly MailServer _mailServer;

        public SendNotificationCommandHandler(MailServer mailServer)
        {
            if (mailServer == null) throw new ArgumentNullException("mailServer");
            _mailServer = mailServer;
        }

        public void Handle(SendNotification sendNotification)
        {
            var emails = sendNotification.Receiver.Email;
            string receivers = string.Join(",", emails);
            var mail = new MailMessage();
            mail.From = new MailAddress(sendNotification.Sender.Email.ToString());
            mail.To.Add(receivers);
            mail.Subject = string.Format("{0} shared a link with you");
            mail.Body = "To view the link go to ...";
            _mailServer.Send(mail);
        } 
    }
}