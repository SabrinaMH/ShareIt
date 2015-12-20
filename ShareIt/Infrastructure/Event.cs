using System;

namespace ShareIt.Infrastructure
{
    public abstract class Event : Message
    {
        public Guid Id { get; protected set; }
    }
}