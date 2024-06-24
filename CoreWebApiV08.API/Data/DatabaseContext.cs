using CoreWebApiV08.API.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Data
{
    public class DatabaseContext: IdentityDbContext<ApplicationUser>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<TokenInfo> TokenInfo { get; set; }
    }


}
