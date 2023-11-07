using System.ComponentModel.DataAnnotations;

namespace Flight_System_API.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Mật khảu không được để trống")]
        public string? Password { get; set; }
    }
}
