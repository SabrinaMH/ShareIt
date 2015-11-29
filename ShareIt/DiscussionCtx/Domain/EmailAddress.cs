using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class EmailAddress
    {
        private readonly string _value;

        public EmailAddress(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(value + " cannot be null or white spaces");
            _value = value;
        }

        public static implicit operator string(EmailAddress email)
        {
            return email._value;
        }
    }
}