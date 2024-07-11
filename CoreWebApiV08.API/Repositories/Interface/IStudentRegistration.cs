using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IStudentRegistration
    {
        Task<List<StudentRegistrationModel>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
            );

        Task<StudentRegistrationModel?> GetByIdAsync(int id);

        Task<StudentRegistrationModel> CreateAsync(StudentRegistrationModel registration);

        Task<StudentRegistrationModel?> UpdateAsync(int id, StudentRegistrationModel registration);

        Task<StudentRegistrationModel?> DeleteAsync(int id);
    }
}
