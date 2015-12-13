using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class DiscussionId : Identity
    {
        private readonly Guid _value;

        public DiscussionId()
        {
            _value = Guid.NewGuid();
        }

        public DiscussionId(Guid value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}