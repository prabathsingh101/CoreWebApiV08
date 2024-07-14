namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class AddClassRequestDto
    {
        public string? classname { get; set; }

        public int? teacherid { get; set; }
        public int? courseid { get; set; }

        public int? studentlimit { get; set; }

        public string? description { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public AddClassRequestDto()
        {
            this.createddate = DateTime.UtcNow;
        }
    }
}
