namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    public class FeesHeadDto
    {
        public int id { get; set; }

        public int? classid { get; set; }

        public string? feename { get; set; }

        public decimal? feeamount { get; set; }

        public bool? isstatus { get; set; } = false;
        public string? shortdescription { get; set; }

        public DateTime? createddate { get; set; } = DateTime.UtcNow;

        public DateTime? updateddate { get; set; } = DateTime.UtcNow;

        //navigation
        public Classes.ClassesDto? Class { get; set; }
    }
}
