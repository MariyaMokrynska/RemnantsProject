using System.Drawing;

namespace RemnantsProject.Models
{
    public class ColourViewModel: Data.Colour
    {
        public ColourViewModel() { }
        public ColourViewModel(Data.Colour src) 
        {
            this.Id = src.Id;
            this.Name = src.Name;
            this.Type = src.Type;
            this.Picture = src.Picture;
        }
        public IFormFile? UploadedImage {  get; set; }
    }
}
