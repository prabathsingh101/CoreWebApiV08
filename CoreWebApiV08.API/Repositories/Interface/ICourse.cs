using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Holidays;
using System.Drawing;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ICourse
    {
        Task<List<CourseModel>> GetAllAsync();

        Task<CourseModel?> GetByIdAsync(int id);

        Task<CourseModel> CreateAsync(CourseModel model);

        Task<CourseModel> UpdateAsync(int id, CourseModel model);

        Task<CourseModel?> DeleteAsync(int id);
    }
}
