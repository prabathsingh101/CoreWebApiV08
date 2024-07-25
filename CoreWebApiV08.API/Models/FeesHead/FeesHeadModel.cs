using CoreWebApiV08.API.Models.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.FeesHead
{
    public class FeesHeadModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //
        public int? classid { get; set; }
        // Navigation property for claass
        public Classes.Classes? Class { get; set; }

        public string? feename { get; set; }
        public string? shortdescription { get; set; }

        public decimal? feeamount { get; set; }

        public bool? isstatus { get; set; } = false;

        public DateTime? createddate { get; set; } = DateTime.UtcNow;

        public DateTime? updateddate { get; set; } = DateTime.UtcNow;
        
    }
}
