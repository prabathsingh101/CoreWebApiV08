using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Course;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IAttendance
    {
        Task <AttendanceTypeModel> CreateAsync(AttendanceTypeModel students);

        Task<AttendanceTypeModel> StudentAttnUpdateAsync(int id, AttendanceTypeModel model);

        Task<AttendanceTypeModel> CreateTeacherAsync(AttendanceTypeModel teacher);

        Task<AttendanceTypeModel> TeacherAttnUpdateAsync(int id, AttendanceTypeModel model);

    }
}
