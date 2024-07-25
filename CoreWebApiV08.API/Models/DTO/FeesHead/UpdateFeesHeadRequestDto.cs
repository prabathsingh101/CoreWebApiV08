namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    public class UpdateFeesHeadRequestDto
    {
        public int? classid { get; set; }

        public string? feename { get; set; }

        public decimal? feeamount { get; set; }

        public bool? isstatus { get; set; } = false;
        public string? shortdescription { get; set; }

        public DateTime? updateddate { get; set; } = DateTime.UtcNow;
    }
}
