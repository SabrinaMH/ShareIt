using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.LinkCtx.Domain
{
    public class LinkId : Identity
    {
        private string _value;

        public LinkId(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}