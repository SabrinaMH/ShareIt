using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Initiator
    {
        public Initiator(Name name, EmailAddress email)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");

            Name = name;
            Email = email;
        }

        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }
    }
} 
   