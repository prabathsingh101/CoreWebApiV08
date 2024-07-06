using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TblTeacher
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Name { get; set; }

    public string? Lname { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Degree { get; set; }

    public string? ContactNo { get; set; }

    public string? Proficiency { get; set; }

    public string? Address { get; set; }

    public DateTime? DateofJoining { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModfiedDate { get; set; }
}
