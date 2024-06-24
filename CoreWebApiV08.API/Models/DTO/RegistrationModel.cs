using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.DTO
{
    public class RegistrationModel
    {
        //public string? Name { get; set; }
        
        [Required]
        public string? Username { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? roles { get; set; }
    }
}
