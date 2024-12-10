using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductProject.Domain.Product;

namespace ProductProject.Infra.Data;

//Ate o modulo 13 utilizamos o "DbContext" agora utilizaremos o IdentityDbContext
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Quando damos um "base." estamos chamando a classe pai que no caso é a IdentityDbContext
        // A classe pai IdentityDbContext esta sendo modela dentro do filho ApplicationDbContext 
        base.OnModelCreating(modelBuilder);

        /*
            Foi preciso fazer isso pois quando fizemos o Entity herdar o Notification, o Entity passou a ser obrigado a declarar as variaveis do Notification
            Porem nao queremos isso, simplesmente queremos usar a validação, sem ter esse Ignore o codigo da erro 500 retornando o erro:
            The entity type 'Notification' requires a primary key to be defined.
        */
        modelBuilder.Ignore<Notification>();

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
