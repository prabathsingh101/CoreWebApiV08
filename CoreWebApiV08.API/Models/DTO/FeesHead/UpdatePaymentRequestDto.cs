namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    public class UpdatePaymentRequestDto
    {
        public string? duration { get; set; } = null;

        public DateTime? collectiondate { get; set; }

        public string? paymenttype { get; set; }

        public string? invoiceno { get; set; }

        public string? status { get; set; }

        public decimal? admissionfees { get; set; }

        public decimal? discount { get; set; }

        public decimal? discountamount { get; set; }

        public decimal finalamount { get; set; }

        public string? description { get; set; }

        public bool? islocked { get; set; }

        public bool? isstatus { get; set; }

        public bool? isdeleted { get; set; }

        
        public DateTime? updateddate { get; set; } = DateTime.Now;

        //
        public int? studentid { get; set; }
        public int? classid { get; set; }
    }
}
