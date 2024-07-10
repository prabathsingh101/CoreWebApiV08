using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IStudentRegistration
    {
        Task<List<StudentRegistration>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
            );

        Task<StudentRegistration?> GetByIdAsync(int id);

        Task<StudentRegistration> CreateAsync(StudentRegistration registration);

        Task<StudentRegistration?> UpdateAsync(int id, StudentRegistration registration);

        Task<StudentRegistration?> DeleteAsync(int id);
    }
}
