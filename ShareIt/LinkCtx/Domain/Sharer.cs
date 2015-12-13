using System;

namespace ShareIt.LinkCtx.Domain
{
    public class Sharer 
    {
        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }

        public Sharer(Name name, EmailAddress email)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");
            Name = name;
            Email = email;
        }
    }
}