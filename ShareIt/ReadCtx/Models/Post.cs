namespace ShareIt.ReadCtx.Models
{
    public class Post
    {
        public string BodyText { get; set; }
        public string EmailOfPoster { get; set; }
        public int PostNumber { get; set; }

        public Post(string bodyText, string emailOfPoster, int postNumber)
        {
            BodyText = bodyText;
            EmailOfPoster = emailOfPoster;
            PostNumber = postNumber;
        }
    }
}