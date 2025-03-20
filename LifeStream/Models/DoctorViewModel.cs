using System.ComponentModel.DataAnnotations;

namespace LifeStream.Models
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }

        //[Required(ErrorMessage = "Please upload an image.")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
    }
}
