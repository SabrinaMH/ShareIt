using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class SenderId : Identity
    {
        // TODO: For now this is just the email. Needs to be fixed.
        public SenderId(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", value));

            Value = value;
        }
    }
}