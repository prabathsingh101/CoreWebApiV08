using CoreWebApiV08.API.Models.Admission;
using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IStudent
    {
        Task<List<StudentAdmissionModel>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
            );

        Task<StudentAdmissionModel?> GetByIdAsync(int id);

        Task<StudentAdmissionModel> CreateAsync(StudentAdmissionModel admissionModel);

        Task<StudentAdmissionModel?> UpdateAsync(int id, StudentAdmissionModel admissionModel);

        Task<StudentAdmissionModel?> PartialUpdateAsync(int id, StudentAdmissionModel admissionModel);

        Task<StudentAdmissionModel?> DeleteAsync(int id);

        Task<List<StudentAdmissionModel>> GetAllStudentByClass(int id);
    }
}
