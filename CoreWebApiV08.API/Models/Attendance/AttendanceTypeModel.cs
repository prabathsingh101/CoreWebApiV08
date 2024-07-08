using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Attendance
{
    public class AttendanceTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? classid { get; set; }

        public string? attendancetype { get; set; }

        public DateTime attendancedate { get; set; }
    }
}
