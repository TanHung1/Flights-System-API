using System.ComponentModel.DataAnnotations;

namespace Flight_System_API.Models
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }
            string email = value.ToString().ToLower();
            if (!email.EndsWith("@vietjetair.com"))
            {
                return false;
            }
            if (email.EndsWith("@gmail.com"))
            {
                return false;
            }
            return true;
        }
    }
}
