using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Kiosk.Models.User;
using Kiosk.Models.Inventory;
using Microsoft.Extensions.Hosting;

namespace Kiosk.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // INVENTORY
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SupplierRepresentatives> SupplierRepresentatives { get; set; }

        // USER
        public DbSet<Users> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        // FOERIGN KEY RELATIONSHIPS
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductCategories)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BlogUrl)
                .HasPrincipalKey(b => b.Url);

            modelBuilder.Entity<Users>()
                .HasMany(t => t.UserRole)
                .WithMany(g => g.Users)
                .UsingEntity<Users_UserRole>
                 (tg => tg.HasOne<User_Role>().WithMany(),
                  tg => tg.HasOne<Access>().WithMany());
        }*/
        
    }

}
