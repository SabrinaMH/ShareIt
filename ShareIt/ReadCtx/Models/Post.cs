namespace ShareIt.ReadCtx.Models
{
    public class Post
    {
        public string BodyText { get; set; }
        public Poster Poster { get; set; }

        public Post(string bodyText, Poster poster)
        {
            BodyText = bodyText;
            Poster = poster;
        }
    }
}