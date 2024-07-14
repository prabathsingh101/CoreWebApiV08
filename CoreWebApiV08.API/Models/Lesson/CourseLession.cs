using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreWebApiV08.API.Models.Course;

namespace CoreWebApiV08.API.Models.Lesson
{
    public class CourseLession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? title { get; set; }
        public string? description { get; set; }

        public DateTime? duration { get; set; }

        public int? seqno { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        //
        public int? courseid { get; set; }
        // Navigation property for claass
        public CourseModel? Course { get; set; }
    }
}
