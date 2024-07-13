using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Classes
{
    public class AttendanceTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }        

        public DateTime? attendancedate { get; set; }

        public string? AttendanceType { get; set; }
        //
        public int? classid { get; set; }
        // Navigation property for claass
        public Classes? Class { get; set; }

        public int? teacherid { get; set; }
        // Navigation property for teacher
        public Teachers.TeacherModel? Teacher { get; set; }

        public int? studentid { get; set; }
        // Navigation property for student
        public StudentAdmissionModel? Student { get; set; }
    }
}
