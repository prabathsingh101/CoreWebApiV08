using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.DTO.Classes
{
    
    public class AdmissionDto
    {
        public int? id { get; set; }

        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }
        public string? fullname { get; set; }
        public string? gender { get; set; }
        public DateTime? registrationdate { get; set; }
        public DateTime? admissiondate { get; set; }
        public decimal? registrationfees { get; set; }

        public string? mobileno { get; set; }
        public bool? isDeleted { get; set; }
        public bool? isStatus { get; set; }
        public string? address { get; set; }

        public int? classid { get; set; }
        public string? fathersname { get; set; }
        public IFormFile? File { get; set; }

        public string? FileName { get; set; }

        public string? FileDescription { get; set; }

        
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
        public Classes.ClassesDto? Class { get; set; }
    }
}
