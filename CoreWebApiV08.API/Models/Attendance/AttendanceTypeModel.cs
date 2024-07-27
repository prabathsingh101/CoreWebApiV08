using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Teachers;

namespace CoreWebApiV08.API.Models.Attendance
{
    public class AttendanceTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime? date { get; set; }

        //public int? classid { get; set; }
        //public int? teacherid { get; set; }
        //public int? studentid { get; set; }
        public bool? isSelected { get; set; }
        public string? type { get; set; }

        //
        public int? studentid { get; set; }
        public int? classid { get; set; }
        public int? teacherid { get; set; }

        // Navigation property for claass
        public Classes.StudentAdmissionModel? Student { get; set; }
        public Classes.Classes? Class { get; set; }
        public Teachers.TeacherModel? Teacher { get; set; }
    }
}
