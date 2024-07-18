﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.Attendance
{
    public class AttendanceTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime? date { get; set; }

        public int? classid { get; set; }
        public int? teacherid { get; set; }
        public int? studentid { get; set; }
        public bool? isSelected { get; set; }
        public string? type { get; set; }
    }
}
