using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.Classes
{
    [Keyless]
    public class MapTeacherModel
    {
        public int? id { get; set; }

        public string? classname { get; set; }

        public int? studentlimit { get; set; }

        public string? teachername { get; set; }
    }
}
