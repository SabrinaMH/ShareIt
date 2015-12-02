using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string value)
        {
            Value = value;
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", value));
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }
    }
}