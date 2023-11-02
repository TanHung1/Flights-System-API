using System.ComponentModel.DataAnnotations;

namespace Flight_System_API.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Passworrd is required")]
        public string? Password { get; set; }
    }
}
