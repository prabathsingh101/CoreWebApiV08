namespace CoreWebApiV08.API.Models.DTO.Attendance
{
    public class UpdateAttendanceRequestDto
    {
        public DateTime? date { get; set; }

        public int? classid { get; set; }
        public int? teacherid { get; set; }
        public int? studentid { get; set; }
        public bool? isSelected { get; set; }
        public string? type { get; set; }
    }
}
