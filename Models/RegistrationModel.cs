using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Models
{
    public class RegistrationModel
    {
        //add reg ex 
        [Required]
        [Phone]
        [RegularExpression(@"(\+\d)?\d{10}")]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        [MinLength(4)]
        [Compare("Password")]
        public string RepeatedPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
