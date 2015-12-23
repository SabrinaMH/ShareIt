using System;
using ShareIt.Infrastructure;

namespace ShareIt.UserCtx.Commands
{
    public class RegisterUser : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public RegisterUser(string name, string email)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", name));
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", email));

            Name = name;
            Email = email;
        }
    }
}