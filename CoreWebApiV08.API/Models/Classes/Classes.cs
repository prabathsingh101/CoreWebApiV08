using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Classes
{
    public class Classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? classname { get; set; }

        public int? teacherid { get; set; }

        public int? studentlimit { get; set; }

        public string? description { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public Classes()
        {
            this.createddate = DateTime.UtcNow;
            this.updateddate = DateTime.UtcNow;
        }
    }
}
