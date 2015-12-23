using System;

namespace ShareIt.LinkCtx.Domain
{
    public class Sharer 
    {
        public EmailAddress Email { get; private set; }

        public Sharer(EmailAddress email)
        {
            if (email == null) throw new ArgumentNullException("email");
            Email = email;
        }
    }
}