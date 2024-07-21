namespace CoreWebApiV08.API.Models.DTO.Teacher
{
    public class TeacherDto
    {
        public int? id { get; set; }
        public string fname { get; set; }
        public string? mname { get; set; }
        public string lname { get; set; }
        public string? email { get; set; }
        public DateTime? dob { get; set; }
        public string? phone { get; set; }
        public string? degree { get; set; }
        public string? contactno { get; set; }
        public string? proficiency { get; set; }
        public string? address { get; set; }
        public string? pincode { get; set; }
        public string? filepath { get; set; }
        public string? gender { get; set; }
        public DateTime? dateofjoining { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? modfieddate { get; set; }
    }
}
