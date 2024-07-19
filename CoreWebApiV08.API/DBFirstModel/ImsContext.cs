using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Models.Teachers;
using CoreWebApiV08.API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class ImsContext : DbContext
{
    public ImsContext()
    {
    }

    public ImsContext(DbContextOptions<ImsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<TblClass> TblClasses { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblHoliday> TblHolidays { get; set; }

    public virtual DbSet<TblLession> TblLessions { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<TblTestModel> TblTestModels { get; set; }

    

    public virtual DbSet<HolidayEvents> getholidayevents {  get; set; }


    public virtual DbSet<UsersModel> userdetails {  get; set; }


    public virtual DbSet<RolesModel> getallroles { get; set; }

    public virtual DbSet<TeacherName> getteachername { get; set; }
    public virtual DbSet<MapTeacherModel> getclassdetails { get; set; }

    public virtual DbSet<Classes> getclassname { get; set; }


    public virtual DbSet<MaxRegNoModel> getmaxregno { get; set; }
    public virtual DbSet<SPRegistrationDetails> getregistrationdetails { get; set; }
    public virtual DbSet<Students> studentdetails { get; set; }
    public virtual DbSet<Teachers> teachersdetails { get; set; }
    public virtual DbSet<AttendanceList> AttendanceList { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.ToTable("TblClass");
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.ToTable("TblCourse");

            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CourseListIcon).HasColumnName("courseListIcon");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IconUrl).HasColumnName("iconUrl");
            entity.Property(e => e.LessonsCount).HasColumnName("lessonsCount");
            entity.Property(e => e.LongDescription).HasColumnName("longDescription");
            entity.Property(e => e.SeqNo).HasColumnName("seqNo");
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.ToTable("TblDepartment");
        });

        modelBuilder.Entity<TblHoliday>(entity =>
        {
            entity.Property(e => e.Color).HasColumnName("color");
        });

        modelBuilder.Entity<TblLession>(entity =>
        {
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.SeqNo).HasColumnName("seqNo");
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.ToTable("TblTeacher");

            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fname).HasColumnName("fname");
            entity.Property(e => e.Lname).HasColumnName("lname");
        });

        modelBuilder.Entity<TblTestModel>(entity =>
        {
            entity.ToTable("TblTestModel");
        });

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
