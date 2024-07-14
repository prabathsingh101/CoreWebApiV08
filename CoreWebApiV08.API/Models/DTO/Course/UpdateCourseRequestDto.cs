namespace CoreWebApiV08.API.Models.DTO.Course
{
    public class UpdateCourseRequestDto
    {
        public string? title { get; set; }

        public string? iconurl { get; set; }

        public string? courselisticon { get; set; }

        public DateTime? duration { get; set; }

        public string? longdescription { get; set; }

        public string? category { get; set; }

        public int? seqno { get; set; }

        public int? lessonscount { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public UpdateCourseRequestDto()
        {
            this.updateddate = DateTime.UtcNow;
        }
    }
}
