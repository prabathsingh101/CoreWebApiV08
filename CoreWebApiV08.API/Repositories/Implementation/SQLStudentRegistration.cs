using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLStudentRegistration : IStudentRegistration
    {
        private readonly DatabaseContext databaseContext;

        public SQLStudentRegistration(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<StudentRegistrationModel> CreateAsync(StudentRegistrationModel registration)
        {
            await databaseContext.TblRegistration.AddAsync(registration);
            await databaseContext.SaveChangesAsync();
            return registration;
        }

        public async Task<StudentRegistrationModel?> DeleteAsync(int id)
        {
            var isExists = await databaseContext.TblRegistration.FirstOrDefaultAsync(x => x.id == id);

            if (isExists == null)
            {
                return null;
            }
            databaseContext.TblRegistration.Remove(isExists);
            databaseContext.SaveChanges();
            return isExists;
        }

        public async Task<List<StudentRegistrationModel>> GetAllAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, 
            int pageNumber = 1, int pageSize = 1000
            )
        {
            var registration = databaseContext.TblRegistration
                .OrderByDescending(a=>a.createddate)
                .ThenByDescending(a=>a.fullname)
                .ThenBy(a=>a.registrationfees)
                .Include("Class").AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("fname", StringComparison.OrdinalIgnoreCase))
                    registration = registration.Where(x => x.fname.Contains(filterQuery));
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("fname", StringComparison.OrdinalIgnoreCase))
                {
                    registration = isAscending ? registration.OrderBy(x => x.fname) : registration.OrderByDescending(x => x.fname);
                }
                else if (sortBy.Equals("lname", StringComparison.OrdinalIgnoreCase))
                {
                    registration = isAscending ? registration.OrderBy(x => x.lname) : registration.OrderByDescending(x => x.lname);
                }
                else if (sortBy.Equals("registrationno", StringComparison.OrdinalIgnoreCase))
                {
                    registration = isAscending ? registration.OrderBy(x => x.registrationno) : registration.OrderByDescending(x => x.registrationno);
                }
                else if (sortBy.Equals("mobileno", StringComparison.OrdinalIgnoreCase))
                {
                    registration = isAscending ? registration.OrderBy(x => x.mobileno) : registration.OrderByDescending(x => x.mobileno);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await registration.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<StudentRegistrationModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblRegistration.Include("Class").FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<StudentRegistrationModel?> UpdateAsync(int id, StudentRegistrationModel registration)
        {
            var isExists = await databaseContext.TblRegistration.FirstOrDefaultAsync(x => x.id == id);

            if (isExists == null)
            {
                return null;
            }

            isExists.registrationno = registration.registrationno;

            isExists.fname = registration.fname;

            isExists.lname = registration.lname;

            isExists.gender = registration.gender;

            //isExists.registrationdate = registration.registrationdate;

            isExists.registrationfees = registration.registrationfees;

            isExists.mobileno = registration.mobileno;

            isExists.classid = registration.classid;

            isExists.fathersname = registration.fathersname;

            isExists.address = registration.address;

            isExists.isStatus = registration.isStatus;

            isExists.islocked = registration.islocked;

            isExists.updateddate = registration.updateddate;

            await databaseContext.SaveChangesAsync();

            return isExists;
        }
    }
}
