using CoreWebApiV08.API.Models.Course;

namespace CoreWebApiV08.API.Models.DTO.Lesson
{
    public class LessonDto
    {
        public int id { get; set; }

        public string? title { get; set; }
        public string? description { get; set; }

        public DateTime? duration { get; set; }

        public int? courseid { get; set; }
        public int? seqno { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        //navigation
        public Course.CourseDto? Course { get; set; }
    }
}
