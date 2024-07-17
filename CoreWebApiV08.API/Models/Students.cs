using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models
{
    [Keyless]
    public class Students
    {
        public int? id { get; set; }
        public string? fullname { get; set; }
        public int? registrationno { get; set; }       
        public int? classid { get; set; }
      

    }
}
