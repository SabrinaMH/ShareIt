using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Topic
    {
        public Topic(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", value));

            Value = value;
        }

        public string Value { get; private set; }
    }
}