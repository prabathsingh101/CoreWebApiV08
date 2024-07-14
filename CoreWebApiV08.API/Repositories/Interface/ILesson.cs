using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Lesson;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ILesson
    {
        Task<List<LessionModel>> GetAllAsync();

        Task<LessionModel?> GetByIdAsync(int id);

        Task<LessionModel> CreateAsync(LessionModel model);

        Task<LessionModel> UpdateAsync(int id, LessionModel model);

        Task<LessionModel?> DeleteAsync(int id);
    }
}
