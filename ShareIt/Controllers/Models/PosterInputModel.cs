using System.ComponentModel.DataAnnotations;

namespace ShareIt.Controllers.Models
{
    public class PosterInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}