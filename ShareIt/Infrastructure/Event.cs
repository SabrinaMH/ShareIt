using System;

namespace ShareIt.Infrastructure
{
    public abstract class Event : Message
    {
        public int Version;
        public Guid Id { get; protected set; }
    }
}