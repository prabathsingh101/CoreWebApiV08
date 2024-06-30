using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLCourse : ICourse
    {
        private readonly DatabaseContext databaseContext;

        public SQLCourse(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<CourseModel>> GetAllCourseAsync()
        {
            return await databaseContext.TblCourse.ToListAsync();
        }

        public async Task<CourseModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblCourse.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
