namespace CoreWebApiV08.API.Models.DTO.Holidays
{
    public class UpdateRequestHolidaysDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? HolidayDate { get; set; }
    }
}
