using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Data
{
    public static class Roles
    {
        public const string USER = "user";
        public const string SALESPERSON = "salesperson";
        public const string ADMIN = "admin";


    }

    [Index("PhoneNumber", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? HomeAddress { get; set; }
        [StringLength(20)]
        public string Role { get; set; }
    }
}
