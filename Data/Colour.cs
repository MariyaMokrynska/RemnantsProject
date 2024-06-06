using System.ComponentModel.DataAnnotations;

namespace RemnantsProject.Data
{
    public enum ColourType
    {
        DARK,
        BRIGHT
    }
    public class Colour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ColourType Type { get; set; } = ColourType.BRIGHT;
        // not required field
        public String? Picture { get; set; } = null;

    }
}
