using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.UserCtx.Domain
{
    public class UserId : Identity
    {
        private string _value;

        public UserId(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}