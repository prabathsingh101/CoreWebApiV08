using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Course
{
    public class CourseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; } 

        public string? title { get; set; }

        public string? iconurl { get; set; }

        public string? courselisticon { get; set; }

        public string? longdescription { get; set; }

        public string? category { get; set; }

        public int? seqno { get; set; }

        public int? lessonscount { get; set; }
        public DateTime? duration { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
    }
}
