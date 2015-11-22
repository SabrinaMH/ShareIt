using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class SenderId
    {
        private Guid _value;

        public SenderId()
        {
            _value = Guid.NewGuid();
        }
    }
}