using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.Attendance
{
    [Keyless]
    public class AttendanceList
    {
        public int attnid { get; set; }
        public string? fullname { get; set; }
        public string? classname { get; set; }
        public DateTime? date { get; set; }
        public string? type { get; set; }
        public bool? isSelected { get; set; }
    }
}
