using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
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

        public async Task<CourseModel> CreateAsync(CourseModel model)
        {
            await databaseContext.TblCourse.AddAsync(model);
            await databaseContext.SaveChangesAsync();
            return model;
        }

        public async Task<CourseModel?> DeleteAsync(int id)
        {
            var isexists = await databaseContext.TblCourse.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }
            databaseContext.TblCourse.Remove(isexists);
            databaseContext.SaveChanges();
            return isexists;
        }

        public async Task<List<CourseModel>> GetAllAsync()
        {
            return await databaseContext.TblCourse.ToListAsync();
        }

        public async Task<CourseModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblCourse.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<CourseModel> UpdateAsync(int id, CourseModel model)
        {
            var isexists = await databaseContext.TblCourse.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }

            isexists.title = model.title;
            isexists.longdescription = model.longdescription;
            isexists.updateddate = model.updateddate;
            isexists.duration = model.duration;

            await databaseContext.SaveChangesAsync();

            return isexists;
        }
    }
}
