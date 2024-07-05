using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLHolidays : IHolidays
    {
        private readonly DatabaseContext databaseContext;

        public SQLHolidays(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<HolidaysModel> CreateAsync(HolidaysModel holidays)
        {
            var output = new SqlParameter();
            output.ParameterName = "@Id";
            output.SqlDbType = SqlDbType.Int;
            output.Direction = ParameterDirection.Output;

            var Title = new SqlParameter("@Title", holidays.Title);

            var Description = new SqlParameter("@Description", holidays.Description);

            var HolidayDate = new SqlParameter("@HolidayDate", holidays.HolidayDate);

            await databaseContext.Database.ExecuteSqlRawAsync("Exec Sp_InsertHolidays @Title,@Description,@HolidayDate", Title, Description, HolidayDate);
            
            return holidays;
        }

        public async Task<HolidaysModel?> DeleteAsync(int id)
        {
            //using sp
            //var idParam = new SqlParameter("@Id", id);
            //await databaseContext.Database.ExecuteSqlRawAsync("Exec Sp_DeleteHolidays @Id", idParam);

            //using ef core
            var existsHoliday = await databaseContext.TblHolidays.FirstOrDefaultAsync(x => x.Id == id);

            if (existsHoliday == null)
            {
                return null;
            }
            databaseContext.TblHolidays.Remove(existsHoliday);
            databaseContext.SaveChanges();
            return existsHoliday;
        }

        public async Task<List<HolidaysModel>> GetAllAsync()
        {
            var holidays = await databaseContext.TblHolidays
                .FromSqlRaw("exec Sp_GetHolidays").IgnoreQueryFilters().ToListAsync();
            return holidays;
        }

        public async Task<HolidaysModel?> GetByIdAsync(int id)
        {
          
            //Its using stored procedure
            var holidays = await databaseContext.TblHolidays
                .FromSqlRaw("exec Sp_GetHolidays").ToListAsync();

            return holidays.FirstOrDefault(x=>x.Id == id);

            // var Id = new SqlParameter("@Id", id);

            //var result= await databaseContext.Database.ExecuteSqlRawAsync("EXEC Sp_GetHolidaysById @Id", Id);

            // return result.ToString();

            //its using EF Core
            //return await databaseContext.TblHolidays.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<HolidaysModel> UpdateAsync(int id, HolidaysModel holidays)
        {
            var Id = new SqlParameter("@Id", id);

            var Title = new SqlParameter("@Title", holidays.Title);

            var Description = new SqlParameter("@Description", holidays.Description);

            var HolidayDate = new SqlParameter("@HolidayDate", holidays.HolidayDate);

            await databaseContext.Database.ExecuteSqlRawAsync("EXEC Sp_UpdateHolidays @Id,@Title,@Description,@HolidayDate", Id, Title, Description, HolidayDate);
           
            return holidays;    
        }
    }
}
