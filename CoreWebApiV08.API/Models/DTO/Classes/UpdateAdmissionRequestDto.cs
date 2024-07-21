namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class UpdateAdmissionRequestDto
    {
       
        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }
        public string? fullname { get; set; }
        public DateTime? registrationdate { get; set; }
        public DateTime? admissiondate { get; set; }
        public decimal? registrationfees { get; set; }
        public bool? isDeleted { get; set; } = false;
        public bool? isStatus { get; set; } = false;
        public string? mobileno { get; set; }

        public string? address { get; set; }

        public int? classid { get; set; }
        public string fathersname { get; set; }

        public IFormFile? File { get; set; }

        public string? FileName { get; set; }

        public string? FileDescription { get; set; }

        public string? FileExtension { get; set; }

        public long? FileSizeBytes { get; set; }

        public string? FilePath { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public UpdateAdmissionRequestDto()
        {
            this.updateddate = DateTime.UtcNow;
        }
    }
}
