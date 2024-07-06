using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiV08.API.Models.DTO.Holidays
{
    public class HolidaysDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? HolidayDate { get; set; }
        public string? color { get; set; }
    }
}
