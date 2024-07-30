using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Models.FeesHead
{
    public class PaymentModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? feestype { get; set; }

        public string? duration { get; set; } = null;

        public DateTime? collectiondate { get; set; }

        public string? paymenttype { get; set; } 

        public string? invoiceno { get; set; }

        public string? status { get; set; }

        public string? feename { get; set; }   
        public string? feeamount { get; set; }

        public decimal? admissionfees { get; set; }        

        public decimal? discount { get; set; }

        public decimal? discountamount { get; set; }

        public decimal totalamount { get; set; }

        public decimal finalamount { get; set; }

        public string? description { get; set; }

        public bool? islocked { get; set; } =false;

        public bool? isselected { get; set; } = false;


        public bool? isstatus { get; set; }=false;  

        public bool? isdeleted { get; set; } = false;   

        public DateTime? createddate { get; set; } = DateTime.Now;

        public DateTime? updateddate { get; set; } = DateTime.Now;

        //
        public int? studentid { get; set; }
        public int? classid { get; set; }
        // Navigation property for claass
        public StudentAdmissionModel? Student { get; set; }
        public Classes.Classes? Class { get; set; }

    }
}
