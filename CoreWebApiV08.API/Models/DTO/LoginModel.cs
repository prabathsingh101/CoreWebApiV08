using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
