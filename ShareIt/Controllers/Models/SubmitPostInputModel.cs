using System.ComponentModel.DataAnnotations;

namespace ShareIt.Controllers.Models
{
    public class SubmitPostInputModel
    {
        [Required]
        public string EmailOfPoster { get; set; }
        
        [Required]
        public string BodyText { get; set; }
    }
}