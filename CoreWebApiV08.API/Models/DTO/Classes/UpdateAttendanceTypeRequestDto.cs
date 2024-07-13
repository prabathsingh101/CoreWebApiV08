namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class UpdateAttendanceTypeRequestDto
    {
        public DateTime? attendancedate { get; set; }

        public string? AttendanceType { get; set; }

        public int? classid { get; set; }

        public int? teacherid { get; set; }

        public int? studentid { get; set; }
    }
}
