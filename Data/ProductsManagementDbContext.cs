using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Models;

namespace src.Data
{
    public class ProductsManagementDbContext : DbContext
    {
        private readonly DbSettings _dbsettings;

        public ProductsManagementDbContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        public DbSet<ProductsManagement> ProductsManagements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
        }

        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<ProductsManagement>()
                .ToTable("ProductsManagement")
                .HasKey(x => x.Id);
         }
    }
}