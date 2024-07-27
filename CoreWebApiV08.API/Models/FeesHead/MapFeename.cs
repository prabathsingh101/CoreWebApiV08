using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.FeesHead
{
    [Keyless]
    public class MapFeename
    {
        public int id { get; set; }

        public int classid { get; set; }

        public string feename { get; set; }    
    }
}
