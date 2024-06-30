using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Department> CreateAsync(Department department)
        {
            await databaseContext.TblDepartment.AddAsync(department);
            await databaseContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var existsDept= await databaseContext.TblDepartment.FirstOrDefaultAsync(x => x.Id == id);

            if (existsDept == null) {
                return null;
            }
            databaseContext.TblDepartment.Remove(existsDept);
            databaseContext.SaveChanges();
            return existsDept;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await databaseContext.TblDepartment.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await databaseContext.TblDepartment.FirstOrDefaultAsync(x => x.Id == id);    
        }

        public async Task<Department?> UpdateAsync(int id, Department department)
        {
            var existsDept = await databaseContext.TblDepartment.FirstOrDefaultAsync(x => x.Id == id);

            if (existsDept == null) 
            { 
                return null; 
            }

            existsDept.DepartmentName = department.DepartmentName;
            existsDept.Description = department.Description;

            await databaseContext.SaveChangesAsync();

            return existsDept;
        }
    }
}
