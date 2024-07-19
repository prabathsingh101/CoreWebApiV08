using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Repositories.Interface;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLAttendance : IAttendance
    {
        private readonly DatabaseContext databaseContext;

        public SQLAttendance(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<AttendanceTypeModel> CreateAsync(AttendanceTypeModel students)
        {
            var isxists = databaseContext.TblAttendanceType.Where(a => a.date == students.date && a.classid == students.classid && a.studentid == students.studentid).FirstOrDefault();
            if (isxists != null)
            {
                return null;
            }
            await databaseContext.TblAttendanceType.AddAsync(students);
            await databaseContext.SaveChangesAsync();
            return students;
        }

        public async Task<AttendanceTypeModel> CreateTeacherAsync(AttendanceTypeModel teacher)
        {
            var isxists = databaseContext.TblAttendanceType.Where(a => a.date == teacher.date && a.classid == teacher.classid && a.teacherid == teacher.teacherid).FirstOrDefault();
            if (isxists != null)
            {
                return null;
            }
            await databaseContext.TblAttendanceType.AddAsync(teacher);
            await databaseContext.SaveChangesAsync();
            return teacher;
        }
    }
}
