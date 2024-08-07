using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Admission;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLStudent: IStudent
    {
        private readonly DatabaseContext databaseContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLStudent(DatabaseContext databaseContext,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            this.databaseContext = databaseContext;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;            
        }
        public async Task<StudentAdmissionModel> CreateAsync(StudentAdmissionModel admissionModel)
        {           

            //add to db
            await databaseContext.TblStudent.AddAsync(admissionModel);
            await databaseContext.SaveChangesAsync();
            return admissionModel;
        }

        public async Task<StudentAdmissionModel?> DeleteAsync(int id)
        {
            var isExists = await databaseContext.TblStudent.FirstOrDefaultAsync(x => x.id == id);

            if (isExists == null)
            {
                return null;
            }
            databaseContext.TblStudent.Remove(isExists);
            databaseContext.SaveChanges();
            return isExists;
        }

        public async Task<List<StudentAdmissionModel>> GetAllAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000
            )
        {
            var admission = databaseContext
                .TblStudent
                .OrderByDescending(a=>a.registrationno)
                .ThenByDescending(a=>a.fname)
                .ThenBy(a=>a.fullname)
                .Include("Class").AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("fname", StringComparison.OrdinalIgnoreCase))
                    admission = admission.Where(x => x.fname.Contains(filterQuery));
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("fname", StringComparison.OrdinalIgnoreCase))
                {
                    admission = isAscending ? admission.OrderBy(x => x.fname) : admission.OrderByDescending(x => x.fname);
                }
                else if (sortBy.Equals("lname", StringComparison.OrdinalIgnoreCase))
                {
                    admission = isAscending ? admission.OrderBy(x => x.lname) : admission.OrderByDescending(x => x.lname);
                }
                else if (sortBy.Equals("registrationno", StringComparison.OrdinalIgnoreCase))
                {
                    admission = isAscending ? admission.OrderBy(x => x.registrationno) : admission.OrderByDescending(x => x.registrationno);
                }
                else if (sortBy.Equals("mobileno", StringComparison.OrdinalIgnoreCase))
                {
                    admission = isAscending ? admission.OrderBy(x => x.mobileno) : admission.OrderByDescending(x => x.mobileno);
                }
                else if (sortBy.Equals("admissiondate", StringComparison.OrdinalIgnoreCase))
                {
                    admission = isAscending ? admission.OrderBy(x => x.admissiondate) : admission.OrderByDescending(x => x.admissiondate);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await admission.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<List<StudentAdmissionModel>> GetAllStudentByClass(int id)
        {
            return await databaseContext.TblStudent.Where(x => x.classid == id).ToListAsync();
        }

        public async Task<StudentAdmissionModel?> GetByIdAsync(int id)
        {
            return await databaseContext.TblStudent.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<StudentAdmissionModel?> PartialUpdateAsync(int id, StudentAdmissionModel admissionModel)
        {
            var isExists = await databaseContext.TblStudent.FirstOrDefaultAsync(x => x.id == id);

            if (isExists == null)
            {
                return null;
            }

            isExists.isStatus = admissionModel.isStatus;

            await databaseContext.SaveChangesAsync();

            return isExists;    
        }

        public async Task<StudentAdmissionModel?> UpdateAsync(int id, StudentAdmissionModel admissionModel)
        {
            var isExists = await databaseContext.TblStudent.FirstOrDefaultAsync(x => x.id == id);

            if (isExists == null)
            {
                return null;
            }

            isExists.registrationno = admissionModel.registrationno;

            isExists.fname = admissionModel.fname;

            isExists.lname = admissionModel.lname;

            isExists.fullname = admissionModel.fullname;

            isExists.gender = admissionModel.gender;

            isExists.registrationdate = admissionModel.registrationdate;

            isExists.admissiondate = admissionModel.admissiondate;

            isExists.registrationfees = admissionModel.registrationfees;

            isExists.mobileno = admissionModel.mobileno;

            isExists.classid = admissionModel.classid;

            isExists.fathersname = admissionModel.fathersname;

            isExists.address = admissionModel.address;

            isExists.isStatus = admissionModel.isStatus;

            isExists.updateddate = admissionModel.updateddate;

            await databaseContext.SaveChangesAsync();

            return isExists;
        }

       
    }
}
