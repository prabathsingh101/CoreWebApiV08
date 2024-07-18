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
            await databaseContext.TblAttendanceType.AddAsync(students);
            await databaseContext.SaveChangesAsync();
            return students;
        }
    }
}
