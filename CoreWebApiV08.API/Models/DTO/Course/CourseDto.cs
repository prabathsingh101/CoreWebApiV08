namespace CoreWebApiV08.API.Models.DTO.Course
{
    public class CourseDto
    {
        public int? Id { get; set; }

        public string? description { get; set; }

        public string? iconUrl { get; set; }

        public string? courseListIcon { get; set; }

        public string? longDescription { get; set; }

        public string? category { get; set; }

        public int? seqNo { get; set; }

        public int? lessonsCount { get; set; }
    }
}
