using System;

namespace ShareIt.LinkCtx.Domain
{
    public class Name
    {
        private string _name;

        public Name(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", name));
            _name = name;
        }

        public static implicit operator string(Name name)
        {
            return name._name;
        }
    }
}