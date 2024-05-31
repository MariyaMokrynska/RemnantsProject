using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Data
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]    
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
