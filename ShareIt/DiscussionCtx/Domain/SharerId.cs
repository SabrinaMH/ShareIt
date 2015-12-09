using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class SharerId : Identity
    {
        // TODO: For now this is just the email. Needs to be fixed.
        public SharerId(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", value));

            Value = value;
        }
    }
}