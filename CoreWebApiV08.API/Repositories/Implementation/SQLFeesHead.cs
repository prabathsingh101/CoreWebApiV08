using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLFeesHead : IFeesHead
    {
        private readonly DatabaseContext databaseContext;

        public SQLFeesHead(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<FeesHeadModel> CreateAsync(FeesHeadModel model)
        {
            await databaseContext.TblFeesHead.AddAsync(model);
            await databaseContext.SaveChangesAsync();
            return model;
        }

        public async Task<FeesHeadModel?> DeleteAsync(int id)
        {
            var isexists = await databaseContext.TblFeesHead.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }
            databaseContext.TblFeesHead.Remove(isexists);
            databaseContext.SaveChanges();
            return isexists;
        }

        public async Task<List<FeesHeadModel>> GetAllAsync()
        {
            return await databaseContext.TblFeesHead
                .OrderByDescending(x => x.feename)
                .ThenByDescending(x => x.createddate)
                .Include("Class").ToListAsync();
        }

        public async Task<FeesHeadModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblFeesHead
                .OrderByDescending(x=>x.feename)
                .ThenByDescending(x=>x.createddate)  
                .Include("Class").FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<FeesHeadModel> UpdateAsync(int id, FeesHeadModel model)
        {
            var isexists = await databaseContext.TblFeesHead.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }

            isexists.classid = model.classid;

            isexists.feename = model.feename;

            isexists.updateddate = model.updateddate;

            isexists.feeamount = model.feeamount;

            isexists.isstatus = model.isstatus;

            isexists.shortdescription = model.shortdescription;

            await databaseContext.SaveChangesAsync();

            return isexists;
        }
    }
}
