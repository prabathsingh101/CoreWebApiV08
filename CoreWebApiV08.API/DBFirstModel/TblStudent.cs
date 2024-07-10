using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TblStudent
{
    public int Id { get; set; }

    public int? Registrationno { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public DateTime? Registrationdate { get; set; }

    public DateTime? Admissiondate { get; set; }

    public decimal? Registrationfees { get; set; }

    public string? Mobileno { get; set; }

    public string? Address { get; set; }

    public int? Classid { get; set; }

    public string Fathersname { get; set; } = null!;

    public DateTime? Createddate { get; set; }

    public DateTime? Updateddate { get; set; }

    public bool? IsDeleted { get; set; }
}
