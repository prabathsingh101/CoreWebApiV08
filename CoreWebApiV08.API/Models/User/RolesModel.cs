using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.User
{
    [Keyless]
    public class RolesModel
    {
        public string? id { get; set; }

        public string? name { get; set; }    
    }
}
