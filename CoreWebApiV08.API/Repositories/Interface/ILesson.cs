using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Lesson;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ILesson
    {
        Task<List<CourseLessionModel>> GetAllAsync();

        Task<CourseLessionModel?> GetByIdAsync(int id);

        Task<CourseLessionModel> CreateAsync(CourseLessionModel model);

        Task<CourseLessionModel> UpdateAsync(int id, CourseLessionModel model);

        Task<CourseLessionModel?> DeleteAsync(int id);
    }
}
