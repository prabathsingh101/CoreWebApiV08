﻿namespace CoreWebApiV08.API.Models.DTO.Classes
{
    public class UpdateRequestRegistrationDto
    {
        public int? registrationno { get; set; }

        public string? fname { get; set; }

        public string? lname { get; set; }
        public string? fullname { get; set; }
        public DateTime? registrationdate { get; set; }

        public decimal? registrationfees { get; set; }

        public int? mobileno { get; set; }
        public string? address { get; set; }
        public bool? isDeleted { get; set; }
        public bool? isStatus { get; set; }
        public int? classid { get; set; }
        public string fathersname { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }

        public UpdateRequestRegistrationDto()
        {
            this.updateddate = DateTime.UtcNow;
        }
    }
}
