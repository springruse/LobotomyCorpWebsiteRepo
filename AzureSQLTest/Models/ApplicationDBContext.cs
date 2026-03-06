namespace AzureSQLTest.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your tables will go here, like:
        // public DbSet<YourModel> YourModels { get; set; }
        public DbSet<BioWeapon> BioWeapons { get; set; }
    }
}
