﻿using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO.Classes;

namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    public class PaymentDto
    {
        public int id { get; set; }

        public string? feestype { get; set; }

        public string? duration { get; set; } = null;

        public DateTime? collectiondate { get; set; }

        public string? paymenttype { get; set; }

        public string? invoiceno { get; set; }

        public string? status { get; set; }

        public decimal? admissionfees { get; set; }
        public string? feename { get; set; }
        public string? feeamount { get; set; }

        public decimal? discount { get; set; }

        public decimal? discountamount { get; set; }
        public decimal totalamount { get; set; }
        public decimal finalamount { get; set; }

        public string? description { get; set; }

        public bool? isselected { get; set; } = false;

        public bool? islocked { get; set; }

        public bool? isstatus { get; set; }

        public bool? isdeleted { get; set; }

        public DateTime? createddate { get; set; } = DateTime.Now;

        public DateTime? updateddate { get; set; } = DateTime.Now;

      
        // Navigation property for claass
        public Classes.AdmissionDto? Student { get; set; }
        public Classes.ClassesDto? Class { get; set; }
    }
}
