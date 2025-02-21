using Microsoft.EntityFrameworkCore;

namespace HomeEnergyApi.Models
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }

        public DbSet<UtilityProvider> UtilityProviders { get; set; }
        public DbSet<HomeUsageData> HomeUsageDatas { get; set; }

        public DbSet<UtilityProvider> UtilityProviders {get; set;}
        public DbSet<HomeUtilityProvider> HomeUtilityProviders {get; set;}
    }
}