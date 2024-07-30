using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.Admission
{
    public class PartialStudentAdmissionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   

        public int id { get; set; }

        public bool? isStatus { get; set; }
    }
}
