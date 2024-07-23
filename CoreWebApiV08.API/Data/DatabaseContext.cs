using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.Domain;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Models.Lesson;
using CoreWebApiV08.API.Models.Teachers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<TokenInfo> TokenInfo { get; set; }

        public DbSet<CourseModel> TblCourse { get; set; }

        public DbSet<LessionModel> TblLessions { get; set; }

        public DbSet<testmodel> TblTestModel { get; set; }

        public DbSet<Department> TblDepartment { get; set; }

        public DbSet<Classes> TblClass { get; set; }

        public DbSet<HolidaysModel> TblHolidays { get; set; }

        public DbSet<TeacherModel> TblTeacher { get; set; }
        public DbSet<StudentRegistrationModel> TblRegistration { get; set; }
        public DbSet<StudentAdmissionModel> TblStudent { get; set; }
        public DbSet<AttendanceTypeModel> TblAttendanceType { get; set; }
        public DbSet<Images> TblStudentDocs { get; set; }
        public DbSet<EmployeeModel> TblEmployee { get; set; }
    }


}
