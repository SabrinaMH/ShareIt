using System;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.NotificationCtx.Domain
{
    public class Receiver
    {
        public Receiver(EmailAddress email)
        {
            if (email == null) throw new ArgumentNullException("email");
            Email = email;
        }

        public EmailAddress Email { get; private set; }
    }
}