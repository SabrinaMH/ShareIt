using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Poster
    {
        public Name Name { get; private set; }
        public EmailAddress EmailAddress { get; set; }

        public Poster(Name name, EmailAddress emailAddress)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (emailAddress == null) throw new ArgumentNullException("emailAddress");
            Name = name;
            EmailAddress = emailAddress;
        }
    }
}