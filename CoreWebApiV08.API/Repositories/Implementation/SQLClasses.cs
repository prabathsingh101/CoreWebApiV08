﻿using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLClasses : IClasses
    {
        private readonly DatabaseContext databaseContext;

        public SQLClasses(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<Classes> CreateAsync(Classes classes)
        {
            await databaseContext.TblClass.AddAsync(classes);
            await databaseContext.SaveChangesAsync();
            return classes;
        }

        public Task<AttendanceTypeModel> CreateAttendanceAsync(AttendanceTypeModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task<AttendanceTypeModel> CreateAttendanceAsync(AttendanceTypeModel model)
        //{
        //    await databaseContext.TblAttendanceType.AddAsync(model);
        //    await databaseContext.SaveChangesAsync();
        //    return model;
        //}

        public async Task<Classes?> DeleteAsync(int id)
        {
            var existsClass = await databaseContext.TblClass.FirstOrDefaultAsync(x => x.id == id);

            if (existsClass == null)
            {
                return null;
            }
            databaseContext.TblClass.Remove(existsClass);
            databaseContext.SaveChanges();
            return existsClass;
        }

        public async Task<List<Classes>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var classes = databaseContext.TblClass
                .Include("Course")
                .Include("Teacher").AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("classname", StringComparison.OrdinalIgnoreCase))
                    classes = classes.Where(x => x.classname.Contains(filterQuery));
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("classname", StringComparison.OrdinalIgnoreCase))
                {
                    classes = isAscending ? classes.OrderBy(x => x.classname) : classes.OrderByDescending(x => x.classname);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    classes = isAscending ? classes.OrderBy(x => x.teacherid) : classes.OrderByDescending(x => x.teacherid);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await classes.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<List<AttendanceTypeModel>> GetAllAttendanceAsync()
        {
            return await databaseContext.TblAttendanceType
                .Include("Class")
                .Include("Student")
                .Include("Teacher").ToListAsync();
         
        }

        public Task<AttendanceTypeModel?> GetAttendanceByClassIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AttendanceTypeModel?> GetAttendanceByIdAsync(int id)
        {
            return await databaseContext.TblAttendanceType
                .Include("Class")
                .Include("Teacher")
                .Include("Student").FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Classes?> GetByIdAsync(int id)
        {
            return await databaseContext.TblClass
                .Include("Course")
                .Include("Teacher").FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<StudentAdmissionModel?> GetStudentByClassIdAsync(int classid)
        {
            return await databaseContext.TblStudent
                .Include("Class")
                .FirstOrDefaultAsync(x => x.classid == classid);
        }

        public async Task<Classes?> UpdateAsync(int id, Classes classes)
        {
            var existsclasses = await databaseContext.TblClass.FirstOrDefaultAsync(x => x.id == id);

            if (existsclasses == null)
            {
                return null;
            }

            existsclasses.classname = classes.classname;
            existsclasses.teacherid = classes.teacherid;
            existsclasses.studentlimit = classes.studentlimit;
            existsclasses.courseid = classes.courseid; 
           
            existsclasses.updateddate = DateTime.UtcNow;

            await databaseContext.SaveChangesAsync();

            return existsclasses;
        }

      
    }
}
