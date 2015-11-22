using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using ShareIt.EventStore;
using ShareIt.ShareLinkCtx.Domain;
using ShareIt.ShareLinkCtx.DomainServices;
using ShareIt.ShareLinkCtx.Events;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLinkCommandHandler
    {
        private readonly Repository<Sender> _repository;
        private readonly MailService _mailService;

        public ShareLinkCommandHandler(MailService mailService, Repository<Sender> repository)
        {
            _repository = repository;
            _mailService = mailService;
        }

        public void Handle(ShareLink message)
        {
            var sender = _repository.ById(message.SenderId);

            var mail = new MailMessage();
            var emails = message.Receivers.GetEmails();
            string receivers = string.Join(",", emails);
            mail.To.Add(receivers);
            mail.From = new MailAddress(sender.Email.ToString());
            mail.Subject = string.Format("{0} shared a link on {1} with you", sender.Name, message.Subject);
            mail.Body = "To view the link go to ...";

            sender.ShareLink(_mailService, mail);
            _repository.Save(sender, message.OriginalVersion);
        }
    }
}