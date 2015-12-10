using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class EmailAddress
    {
        public EmailAddress(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            Value = value;
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(value + " cannot be null or white spaces");
            Value = value;
        }

        public string Value { get; set; }

        public static implicit operator string(EmailAddress email)
        {
            return email.Value;
        }
    }
}