using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.Teachers
{
    public class TeacherModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? fname { get; set; }
        public string? Name { get; set; }
        public string? lname { get; set; }
        public string? email { get; set; }
        public DateTime? dob { get; set; }
        public string? Phone { get; set; }
        public string? Degree { get; set; }
        public string? ContactNo { get; set; }
        public string? Proficiency { get; set; }
        public string? Address { get; set; }
        public DateTime? DateofJoining { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModfiedDate { get; set; }
        
    }
}
