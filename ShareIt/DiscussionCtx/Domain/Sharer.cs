using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Sharer
    {
        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }

        public Sharer(Name name, EmailAddress email) 
        {
            Name = name;
            Email = email;
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");
        }
    }
}