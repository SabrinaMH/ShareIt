using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class SenderId : Identity
    {
        public SenderId()
        {
            Value = Guid.NewGuid();
        }
    }
}