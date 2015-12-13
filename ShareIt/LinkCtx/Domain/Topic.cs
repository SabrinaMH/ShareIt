using System;

namespace ShareIt.LinkCtx.Domain
{
    public class Topic
    {
        private string _value;

        public Topic(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", value));

            _value = value;
        }

        public static implicit operator string(Topic topic)
        {
            return topic._value;
        }
    }
}