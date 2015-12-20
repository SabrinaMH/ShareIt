namespace ShareIt.ReadCtx.Models
{
    public class Post
    {
        public string BodyText { get; set; }
        public string NameOfPoster { get; set; }

        public Post(string bodyText, string nameOfPoster)
        {
            BodyText = bodyText;
            NameOfPoster = nameOfPoster;
        }
    }
}