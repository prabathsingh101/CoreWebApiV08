using Microsoft.AspNetCore.Identity;

namespace CoreWebApiV08.API.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public DateTime? DateofBirth { get; set; }
    }
}
