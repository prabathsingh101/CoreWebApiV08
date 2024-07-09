using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.Teachers;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLTeacher : ITeacher
    {
        private readonly DatabaseContext databaseContext;

        public SQLTeacher(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<TeacherModel> CreateAsync(TeacherModel teacher)
        {
            await databaseContext.TblTeacher.AddAsync(teacher);
            await databaseContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<TeacherModel?> DeleteAsync(int id)
        {
            var existsTeacher = await databaseContext.TblTeacher.FirstOrDefaultAsync(x => x.id == id);

            if (existsTeacher == null)
            {
                return null;
            }
            databaseContext.TblTeacher.Remove(existsTeacher);
            databaseContext.SaveChanges();
            return existsTeacher;
        }

        public async Task<List<TeacherModel>> GetAllAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000
            )
        {
            var teachers =  databaseContext.TblTeacher.AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("fname", StringComparison.OrdinalIgnoreCase))
                    teachers = teachers.Where(x => x.fname.Contains(filterQuery));
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("fname", StringComparison.OrdinalIgnoreCase))
                {
                    teachers = isAscending ? teachers.OrderBy(x => x.fname) : teachers.OrderByDescending(x => x.fname);
                }
                else if (sortBy.Equals("lname", StringComparison.OrdinalIgnoreCase))
                {
                    teachers = isAscending ? teachers.OrderBy(x => x.lname) : teachers.OrderByDescending(x => x.lname);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await teachers.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<TeacherModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblTeacher.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<TeacherModel?> UpdateAsync(int id, TeacherModel teacher)
        {
            var existsTeacher = await databaseContext.TblTeacher.FirstOrDefaultAsync(x => x.id == id);

            if (existsTeacher == null)
            {
                return null;
            }

            existsTeacher.fname = teacher.fname;
            existsTeacher.mname = teacher.mname;
            existsTeacher.lname = teacher.lname;
            existsTeacher.email = teacher.email;
            existsTeacher.dob = teacher.dob;
            existsTeacher.phone = teacher.phone;
            existsTeacher.degree = teacher.degree;
            existsTeacher.proficiency = teacher.proficiency;
            existsTeacher.address = teacher.address;
            existsTeacher.dateofjoining = teacher.dateofjoining;
            existsTeacher.pincode = teacher.pincode;
            existsTeacher.createddate = DateTime.UtcNow;
            existsTeacher.modfieddate = DateTime.UtcNow;

            await databaseContext.SaveChangesAsync();

            return existsTeacher;
        }
    }
}
