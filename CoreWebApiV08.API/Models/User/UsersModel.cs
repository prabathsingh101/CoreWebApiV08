using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.User
{
    [Keyless]
    public class UsersModel
    {
        public string? id { get; set; }
        public string? name { get; set; }

        public string? username { get; set; }

        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public string? address { get; set; }

        public string? mobileno { get; set; }

        public string? email { get; set; }

        public string? role { get; set; }
    }
}
