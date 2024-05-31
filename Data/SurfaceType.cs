using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Data
{
    public class SurfaceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
