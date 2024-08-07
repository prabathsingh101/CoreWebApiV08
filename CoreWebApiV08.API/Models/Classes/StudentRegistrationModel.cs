using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
namespace CoreWebApiV08.API.Models.Classes
{
    public class StudentRegistrationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }

        public string? fullname { get; set; }

        public string? gender { get; set; }

        public DateTime? registrationdate { get; set; }

        public decimal? registrationfees { get; set; }

        public string? mobileno { get; set; }

        public string? address { get; set; }
        
        public string? fathersname { get; set; }

        public bool? isDeleted { get; set; } = false;

        public bool? isStatus { get; set; } = false;

        public bool? islocked { get; set; } = false;

        public DateTime? createddate { get; set; }

        public DateTime? updateddate { get; set; }
        //
        public int? classid { get; set; }
        // Navigation property for claass
        public Classes? Class { get; set; }

    }
}
