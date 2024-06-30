using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Lesson;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLLesson : ILesson
    {
        private readonly DatabaseContext databaseContext;

        public SQLLesson(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public Task<List<CourseLession>> GetAllLessonAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CourseLession> GetLessionBycourseIdAsync(int CourseId)
        {
            return await databaseContext.TblLessions.FirstOrDefaultAsync(x => x.CourseId == CourseId);
        }
    }
}
