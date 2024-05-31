using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Models
{
    public class LoginModel
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
