using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;

namespace ShareIt.API.Models
{
    public class SubmitPostInputModel
    {
        [Required]
        public PosterInputModel Poster { get; set; }
        
        [Required]
        public string BodyText { get; set; }
    }
}