using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TblHoliday
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? HolidayDate { get; set; }
}
