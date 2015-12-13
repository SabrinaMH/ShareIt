using ShareIt.Infrastructure;

namespace ShareIt.SharerCtx.Events
{
    public class SharerRegistered : Event
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public SharerRegistered(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}