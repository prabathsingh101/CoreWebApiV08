using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CoreWebApiV08.API.Models.Holidays
{
    [Keyless]
    public class HolidayEvents
    {        
        public string? title { get; set; }

        public string? color { get; set; }

        public DateTime? start { get; set; }
    }
}
