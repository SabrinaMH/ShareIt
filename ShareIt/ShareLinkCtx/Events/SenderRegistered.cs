﻿using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Events
{
    public class SenderRegistered : Event
    {
        public SenderId Id { get; private set; }
        public Name Name { get; private set; }
        public EmailAddress Email { get; private set; }

        public SenderRegistered(SenderId id, Name name, EmailAddress email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}