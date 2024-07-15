using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Teachers;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IClasses
    {
        Task<List<Classes>> GetAllAsync(string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000);

        Task<Classes?> GetByIdAsync(int id);

        Task<Classes> CreateAsync(Classes classes);

        Task<Classes?> UpdateAsync(int id, Classes classes);

        Task<Classes?> DeleteAsync(int id);


        Task<AttendanceTypeModel> CreateAttendanceAsync(AttendanceTypeModel model);
        Task<AttendanceTypeModel?> GetAttendanceByIdAsync(int id);
        Task<List<AttendanceTypeModel>> GetAllAttendanceAsync();

       // Task<AttendanceTypeModel?> GetAttendanceByClassIdAsync(int id);

        Task<StudentAdmissionModel?> GetStudentByClassIdAsync(int classid);
    }
}