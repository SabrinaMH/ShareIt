using ShareIt.Infrastructure;

namespace ShareIt.LinkCtx.Events
{
    public class LinkRegistered : Event
    {
        public string Id { get; private set; }
        public string Uri { get; private set; }

        public LinkRegistered(string id, string uri)
        {
            Id = id;
            Uri = uri;
        }
    }
}