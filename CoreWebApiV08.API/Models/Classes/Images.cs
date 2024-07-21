using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.Classes
{
    public class Images
    {
        public int id { get; set; }

        [NotMapped]
        public IFormFile? file { get; set; }

        public string? filename { get; set; }

        public string? filedescription { get; set; }

        public string? fileextension { get; set; }

        public long? filesizebytes { get; set; }

        public string? filepath { get; set; }

        public string? registrationno { get; set; }
    }
}
