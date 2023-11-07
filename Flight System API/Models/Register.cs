using System.ComponentModel.DataAnnotations;

namespace Flight_System_API.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string? Username { get; set; }
        [Email(ErrorMessage = "Định dạng email phải là @vietjetair.com")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string? Email { get; set; }

        [Required(ErrorMessage = " Số điện thoại không được để trống")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = " Mật khẩu không được để trống")]
        public string? Password { get; set; }


    }
}
