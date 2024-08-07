﻿using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.Classes
{
    [Keyless]
    public class SPRegistrationDetails
    {
        public int? id { get; set; }

        public int? registrationno { get; set; }

        public string? fullname { get; set; }   
        public string? gender { get; set; }

        public DateTime? registrationdate { get; set; }

        public decimal? registrationfees { get; set; }

        public string? mobileno { get; set; }

        public string? address { get; set; }

        public bool? isdeleted { get; set; }

        public string? isstatus { get; set; }
        public bool? islocked { get; set; }

        public string? classname { get; set; }
    }
}
