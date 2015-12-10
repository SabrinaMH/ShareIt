using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class SharerRegistered : Event
    {
        public SharerId Id { get; private set; }
        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }

        public SharerRegistered(SharerId id, Name name, EmailAddress email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}