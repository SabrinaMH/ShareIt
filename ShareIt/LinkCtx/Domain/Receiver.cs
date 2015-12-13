using System;

namespace ShareIt.LinkCtx.Domain
{
    public class Receiver
    {
        public Receiver(EmailAddress email)
        {
            if (email == null) throw new ArgumentNullException("email");
            Email = email;
        }

        public EmailAddress Email { get; private set; }

        public static implicit operator string(Receiver receiver)
        {
            return receiver.Email;
        }
    }
}