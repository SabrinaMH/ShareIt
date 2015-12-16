using System;
using ShareIt.Infrastructure;

namespace ShareIt.SharerCtx.Events
{
    public class SharerRegistered : Event
    {
        public string SharerId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public SharerRegistered(string sharerId, string name, string email)
        {
            SharerId = sharerId;
            Name = name;
            Email = email;
            Id = Guid.NewGuid();
            Version = 0;
        }
    }
}