using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.DTO.Emoloyees
{
    public class AddEmployeeRequestDto
    {
        public string? fname { get; set; }

        public string? lname { get; set; }

        public string? fullname { get; set; }

        public string? email { get; set; } = null;

        public string? phone { get; set; }

        public string? address { get; set; }

        public string? gender { get; set; }

        public string? employeeimage { get; set; }

        [NotMapped]
        public IFormFile? imagefile { get; set; }

        public DateTime? dob { get; set; } = DateTime.Now;

        public DateTime? doj { get; set; } = DateTime.Now;

        public DateTime? createddate { get; set; } = DateTime.Now;
    }
}
