using System;
using System.Net.Mail;
using ShareIt.EventStore;
using ShareIt.ShareLinkCtx.DomainServices;
using ShareIt.ShareLinkCtx.Events;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class Sender : AggregateRoot
    {
        // todo: find way to avoid having a public constructor. Needed for Repository<Sender>
        public Sender() { }

        public Sender(Name name, EmailAddress email)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");

            _id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }
        private Guid _id;

        public override Guid Id
        {
            get { return _id; }
        }

        public void ShareLink(MailService mailService, MailMessage mail)
        {
            if (mailService == null) throw new ArgumentNullException("mailService");
            if (mail == null) throw new ArgumentNullException("mail");

            ApplyChange(new LinkShared(Id));
            mailService.Send(mail);
        }
    }
}