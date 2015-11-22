using System;

namespace ShareIt.NotificationCtx.Domain
{
    public class EmailAddress
    {
        private string _value;

        public EmailAddress(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException(value + " cannot be null or white spaces");
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}