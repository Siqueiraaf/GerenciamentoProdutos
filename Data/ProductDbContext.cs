using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Models;

namespace src.Data
{
    public class ProductDbContext : DbContext
    {
        private readonly DbSettings _dbsettings;

        // Construtor padrão para DbContext
        public ProductDbContext(DbContextOptions<ProductDbContext> options, IOptions<DbSettings> dbSettings)
            : base(options)
        {
            _dbsettings = dbSettings.Value;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura a conexão com o banco de dados usando a string de conexão
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(x => x.Id);
        }
    }
}
