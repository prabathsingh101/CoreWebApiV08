namespace CoreWebApiV08.API.Models.Lesson
{
    public class CourseLession
    {
        public int Id { get; set; }

        public string? description { get; set; }

        public string? duration { get; set; }

        public int? seqNo { get; set; }

        public int? CourseId { get; set; }
    }
}
