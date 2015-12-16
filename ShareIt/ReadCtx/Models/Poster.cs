namespace ShareIt.ReadCtx.Models
{
    public class Poster
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public Poster(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}