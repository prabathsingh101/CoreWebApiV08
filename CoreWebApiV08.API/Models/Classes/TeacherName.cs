using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.Classes
{
    [Keyless]
    public class TeacherName
    {
        public int? id { get; set; }

        public string? name { get; set; }
    }
}
