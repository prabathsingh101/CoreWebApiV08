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

        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
    
        public string? Url { get; set; }

        public DateTime? dob { get; set; }

        public DateTime? doj { get; set; }

        public DateTime? createddate { get; set; } = DateTime.Now;

        public DateTime? updateddate { get; set; } = DateTime.Now;
    }
}
