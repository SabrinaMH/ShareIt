using System;
using ShareIt.Infrastructure;

namespace ShareIt.UserCtx.Events
{
    public class UserRegistered : Event
    {
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserRegistered(string userId, string name, string email)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Id = Guid.NewGuid();
        }
    }
}