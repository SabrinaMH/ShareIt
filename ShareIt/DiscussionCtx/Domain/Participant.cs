using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Participant
    {
        // TODO: Should also have a name
        public Participant(EmailAddress email)
        {
            if (email == null) throw new ArgumentNullException("email");

            Email = email;
        }

        public EmailAddress Email { get; private set; }
    }
}