using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.SharerCtx.Domain
{
    public class SharerId : Identity
    {
        private string _value;

        public SharerId(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}