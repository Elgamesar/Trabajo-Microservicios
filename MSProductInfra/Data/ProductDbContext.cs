using Microsoft.EntityFrameworkCore;
using MSProductDomain.Entities;

namespace MSProductInfra.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuraciones

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description)
                .HasDefaultValue("No description")
                .HasMaxLength(4000);
                entity.Property(e => e.Name)
                .HasMaxLength(300);

                // Other configurations
            });
            base.OnModelCreating(modelBuilder);
        }
        
    }
}