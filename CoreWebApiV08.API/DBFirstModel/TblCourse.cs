using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TblCourse
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? IconUrl { get; set; }

    public string? CourseListIcon { get; set; }

    public string? LongDescription { get; set; }

    public string? Category { get; set; }

    public int? SeqNo { get; set; }

    public int? LessonsCount { get; set; }
}
