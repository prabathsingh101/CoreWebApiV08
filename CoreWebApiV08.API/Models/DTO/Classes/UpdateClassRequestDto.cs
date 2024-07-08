namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class UpdateClassRequestDto
    {
        public string? classname { get; set; }

        public int? teacherid { get; set; }

        public int? studentlimit { get; set; }

        public string? description { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
    }
}
