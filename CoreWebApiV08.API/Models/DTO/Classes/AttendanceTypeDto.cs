using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class AttendanceTypeDto
    {
        public int id { get; set; }

        public DateTime? attendancedate { get; set; }

        public string? AttendanceType { get; set; }

        //navigation field
        public Classes.ClassesDto? Class { get; set; }

        public Teacher.TeacherDto? Teacher { get; set; }

        public AdmissionDto? Student { get; set; }


    }
}
