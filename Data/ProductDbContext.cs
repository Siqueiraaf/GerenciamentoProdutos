using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Models;

namespace src.Data
{
    public class ProductDbContext : DbContext
    {
        private readonly DbSettings _dbsettings;

        public ProductDbContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
        }

        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(x => x.Id);
         }
    }
}