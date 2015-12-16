namespace ShareIt.ReadCtx.Models
{
    public class Participant
    {
        public string Email { get; set; }

        public Participant(string email)
        {
            Email = email;
        }
    }
}