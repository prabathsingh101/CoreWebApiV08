using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLDepartment : IDepartment
    {
        private readonly DatabaseContext databaseContext;

        public SQLDepartment(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Department>> GetAllDeptsync()
        {
            return await databaseContext.TblDepartment.ToListAsync();
        }
    }
}
