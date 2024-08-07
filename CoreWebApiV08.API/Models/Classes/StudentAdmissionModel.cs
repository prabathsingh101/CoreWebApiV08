﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Classes
{
    public class StudentAdmissionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }
        public string? fullname { get; set; }
        public string? gender { get; set; }
        public DateTime? registrationdate { get; set; }
        public DateTime? admissiondate { get; set; }
        public decimal? registrationfees { get; set; }

        public string? mobileno { get; set; }

        public string? address { get; set; }

        public string? fathersname { get; set; }
        public bool? isDeleted { get; set; } = false;

        public bool? isStatus { get; set; } = false;

        [NotMapped]
        public IFormFile? File { get; set; }

        public string? FileName { get; set; }

        public string? FileDescription { get; set; }

        public string? FileExtension { get; set; }

        public long? FileSizeBytes { get; set; }

        public string? FilePath { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        //
        public int? classid { get; set; }
        // Navigation property for claass
        public Classes? Class { get; set; }
    }
}
