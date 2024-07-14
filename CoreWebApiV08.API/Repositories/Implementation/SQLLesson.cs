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

        public async Task<CourseLessionModel> CreateAsync(CourseLessionModel model)
        {
            await databaseContext.TblLessions.AddAsync(model);
            await databaseContext.SaveChangesAsync();
            return model;
        }

        public async Task<CourseLessionModel?> DeleteAsync(int id)
        {
            var isexists = await databaseContext.TblLessions.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }
            databaseContext.TblLessions.Remove(isexists);
            databaseContext.SaveChanges();
            return isexists;
        }

        public async Task<List<CourseLessionModel>> GetAllAsync()
        {
            return await databaseContext.TblLessions.OrderBy(o => o.createddate).ToListAsync();
        }

        public async Task<CourseLessionModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblLessions.OrderByDescending(o => o.createddate).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<CourseLessionModel> UpdateAsync(int id, CourseLessionModel model)
        {
            var isexists = await databaseContext.TblLessions.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }

            isexists.title = model.title;
            isexists.description = model.description;
            isexists.updateddate = model.updateddate;

            await databaseContext.SaveChangesAsync();

            return isexists;
        }
    }
}
