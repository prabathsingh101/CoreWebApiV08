﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Classes
{
    public class StudentAdmissionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }

        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }

        public DateTime? registrationdate { get; set; }
        public DateTime? admissiondate { get; set; }
        public decimal? registrationfees { get; set; }

        public string? mobileno { get; set; }

        public string? address { get; set; }

        public int? classid { get; set; }
        public string fathersname { get; set; }

        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public StudentAdmissionModel()
        {
            this.createddate = DateTime.UtcNow;
            this.updateddate = DateTime.UtcNow;
        }
    }
}