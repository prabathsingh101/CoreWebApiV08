namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class ClassesDto
    {
        public int? id { get; set; }

        public string? classname { get; set; }

        public int? teacherid { get; set; }
        public int? courseid { get; set; }

        public int? studentlimit { get; set; }

        public string? description { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public Teacher.TeacherDto? Teacher { get; set; }
        public Course.CourseDto? Course { get; set; }
    }
}
