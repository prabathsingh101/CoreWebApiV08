namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    public class AddFeesHeadRequestDto
    {
        public int? classid { get; set; }

        public string? feename { get; set; }

        public decimal? feeamount { get; set; }
        public string? shortdescription { get; set; }

        public bool? isstatus { get; set; } = false;

        public DateTime? createddate { get; set; } = DateTime.UtcNow;
    }
}
