using System.ComponentModel.DataAnnotations;

namespace ShareIt.Controllers.Models
{
    public class SubmitPostInputModel
    {
        [Required]
        public PosterInputModel Poster { get; set; }
        
        [Required]
        public string BodyText { get; set; }
    }
}