using System.Runtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace src.Data
{
    public class ProductsManagementDbContext : DbContext
    {
        private readonly DbSettings _dbsettings;

        public ProductsManagementDbContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        public DbSet<ProductsManagementDbContext>  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
        }

        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<>()
                .ToTable("")
                .HasKey(x => x.Id);
         }
    }
}