using ShareIt.Infrastructure;

namespace ShareIt.DiscussionCtx.Events
{
    public class PostSubmitted : Event
    {
        public string NameOfPoster { get; private set; }
        public string EmailAddressOfPoster { get; private set; }
        public string BodyText { get; private set; }

        public PostSubmitted(string nameOfPoster, string emailAddressOfPoster, string bodyText)
        {
            NameOfPoster = nameOfPoster;
            EmailAddressOfPoster = emailAddressOfPoster;
            BodyText = bodyText;
        }
    }
}