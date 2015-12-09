using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Identity
    {
        public Guid Value { get; protected set; }

        public Identity()
        {
            Value = Guid.NewGuid();
        }

        public Identity(Guid id)
        {
            Value = id;
        }

        public static implicit operator Guid(Identity id)
        {
            return id.Value;
        }

        public static implicit operator string(Identity id)
        {
            return id.Value.ToString();
        }
    }
}