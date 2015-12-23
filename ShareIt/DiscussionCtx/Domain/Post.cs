using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Post 
    {
        public EmailAddress EmailOfPoster { get; private set; }
        public string BodyText { get; private set; }
        public int PostNumber { get; private set; }

        public Post(EmailAddress emailOfPoster, string bodyText, int postNumber)
        {
            if (String.IsNullOrWhiteSpace(bodyText))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", bodyText));
            if (emailOfPoster == null) throw new ArgumentNullException("emailOfPoster");
            if (postNumber < 0) throw new ArgumentException(string.Format("{0} cannot be negative", postNumber));

            EmailOfPoster = emailOfPoster;
            BodyText = bodyText;
            PostNumber = postNumber;
        }
    }
}