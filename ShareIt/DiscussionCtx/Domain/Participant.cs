using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Participant
    {
        public Participant(EmailAddress email)
        {
            Email = email;
        }

        public EmailAddress Email { get; private set; }
    }
}