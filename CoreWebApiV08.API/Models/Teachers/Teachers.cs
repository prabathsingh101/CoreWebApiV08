using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.Teachers
{
    [Keyless]
    public class Teachers
    {
        public int? id { get; set; }

        public string? fullname { get; set; }
        public string? classname { get; set; }
        public int? classid { get; set; }
    }
}
