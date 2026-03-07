using Microsoft.EntityFrameworkCore;

namespace AzureSQLTest.Models
{
    public class UserInfoDbContext : DbContext
    {
        public UserInfoDbContext(DbContextOptions<UserInfoDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
