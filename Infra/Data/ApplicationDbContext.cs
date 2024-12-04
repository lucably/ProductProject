using Microsoft.EntityFrameworkCore;
using ProductProject.Domain.Product;

namespace ProductProject.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
               .Property(p => p.Description).HasMaxLength(255);
        modelBuilder.Entity<Product>()
               .Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Product>()
              .Property(p => p.CategoryId).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //Toda prop String terá no max 100 tam
        configurationBuilder.Properties<string>()
            .HaveMaxLength(100);
    }
}
