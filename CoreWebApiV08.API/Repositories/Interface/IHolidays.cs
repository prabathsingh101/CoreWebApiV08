using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.Holidays;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IHolidays
    {
        Task<List<HolidaysModel>> GetAllAsync();
        //Task<List<HolidayEvents>> GetHolidayEventsAsync();

        Task<HolidaysModel?> GetByIdAsync(int id);

        Task <HolidaysModel> CreateAsync(HolidaysModel holidays);

        Task <HolidaysModel> UpdateAsync(int id,HolidaysModel holidays);

        Task <HolidaysModel?> DeleteAsync(int id);
    }
}
