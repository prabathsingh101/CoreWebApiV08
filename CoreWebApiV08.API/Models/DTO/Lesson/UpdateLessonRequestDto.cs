namespace CoreWebApiV08.API.Models.DTO.Lesson
{
    public class UpdateLessonRequestDto
    {
        public string? title { get; set; }
        public string? description { get; set; }

        public DateTime? duration { get; set; }

        public int? courseid { get; set; }
        public int? seqno { get; set; }
        public DateTime? updateddate { get; set; }

        public UpdateLessonRequestDto()
        {
            this.updateddate = DateTime.UtcNow;
        }
    }
}
