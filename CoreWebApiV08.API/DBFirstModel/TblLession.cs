using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TblLession
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Duration { get; set; }

    public int? SeqNo { get; set; }

    public int? CourseId { get; set; }
}
