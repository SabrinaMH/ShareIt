using System;
using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class LinkActorCreated : Event
    {
        public Guid Id { get; private set; }
        public string Uri { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }

        public LinkActorCreated(Guid id, string uri, string email, string name)
        {
            Id = id;
            Uri = uri;
            Email = email;
            Name = name;
        }
    }
}