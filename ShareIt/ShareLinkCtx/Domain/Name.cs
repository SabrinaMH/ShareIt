using System;
 
namespace ShareIt.ShareLinkCtx.Domain
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
    }
}