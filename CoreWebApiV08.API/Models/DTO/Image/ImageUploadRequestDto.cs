using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.DTO.Image
{
    public class ImageUploadRequestDto
    {
        public IFormFile? file { get; set; }

        [Required]
        public string? filename { get; set; }

        public string? filedescription { get; set; }
        public string? registrationno { get; set; }
    }
}
