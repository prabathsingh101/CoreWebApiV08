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

        public async Task<LessionModel> CreateAsync(LessionModel model)
        {
            await databaseContext.TblLessions.AddAsync(model);
            await databaseContext.SaveChangesAsync();
            return model;
        }

        public async Task<LessionModel?> DeleteAsync(int id)
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

        public async Task<List<LessionModel>> GetAllAsync()
        {
            return await databaseContext.TblLessions.Include("Course").OrderBy(o => o.createddate).ToListAsync();
        }

        public async Task<LessionModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblLessions.Include("Course").OrderByDescending(o => o.createddate).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<LessionModel> UpdateAsync(int id, LessionModel model)
        {
            var isexists = await databaseContext.TblLessions.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }

            isexists.title = model.title;
            isexists.courseid = model.courseid; 
            isexists.description = model.description;
            isexists.updateddate = model.updateddate;

            await databaseContext.SaveChangesAsync();

            return isexists;
        }
    }
}
