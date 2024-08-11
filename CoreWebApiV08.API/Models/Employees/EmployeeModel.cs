using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CoreWebApiV08.API.Models.Employees
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }

        public string? fullname {  get; set; }  

        public string? email { get; set; }  = null;

        public string? phone { get; set; }  

        public string? address { get; set; }

        public string? gender { get; set; }

        public string? employeeimage { get; set; }

        [NotMapped]
        public IFormFile? imagefile { get; set; }

        public DateTime? dob { get; set; } = DateTime.Now;

        public DateTime? doj { get; set; } = DateTime.Now;

        public DateTime? createddate { get; set; } = DateTime.Now;

        public DateTime? updateddate { get; set; } = DateTime.Now;
    }
}
