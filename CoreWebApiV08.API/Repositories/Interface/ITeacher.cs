using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.Teachers;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ITeacher
    {
        Task<List<TeacherModel>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
            );

        Task<TeacherModel?> GetByIdAsync(int id);

        Task<TeacherModel> CreateAsync(TeacherModel teacher);

        Task<TeacherModel?> UpdateAsync(int id, TeacherModel teacher);

        Task<TeacherModel?> DeleteAsync(int id);
    }
}
