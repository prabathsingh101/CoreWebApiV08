using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.Domain;
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

        public DbSet<CourseLession> TblLessions { get; set; }

        public DbSet<testmodel> TblTestModel { get; set; }

        public DbSet<Department> TblDepartment { get; set; }

        public DbSet<Classes> TblClass { get; set; }

        public DbSet<HolidaysModel> TblHolidays { get; set; }

        public DbSet<TeacherModel> TblTeacher { get; set; }
        public DbSet<StudentRegistrationModel> TblRegistration { get; set; }
        public DbSet<StudentAdmissionModel> TblStudent { get; set; }
    }


}
