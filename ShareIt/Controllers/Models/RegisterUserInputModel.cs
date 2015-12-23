using System.ComponentModel.DataAnnotations;

namespace ShareIt.Controllers.Models
{
    public class RegisterUserInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}