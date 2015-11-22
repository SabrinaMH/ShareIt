using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class Sender
    {
        public Sender(Name name, EmailAddress email)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");
            _name = name;
            Email = email;
            _id = new SenderId();
        }

        private readonly SenderId _id;
        private Name _name;
        public EmailAddress Email { get; private set; }
    }
}