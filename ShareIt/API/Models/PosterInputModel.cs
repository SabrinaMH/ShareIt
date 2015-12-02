using System.ComponentModel.DataAnnotations;

namespace ShareIt.API.Models
{
    public class PosterInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}