using CoreWebApiV08.API.Models.Course;
using System.Drawing;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ICourse
    {
        Task<List<CourseModel>> GetAllCourseAsync();

        Task<CourseModel?> GetByIdAsync(int id);
    }
}
