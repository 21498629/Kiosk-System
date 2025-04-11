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
        public DbSet<UserRoles> UserRole { get; set; }

        // FOERIGN KEY RELATIONSHIPS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USERS AND USER ROLES

            modelBuilder.Entity<Users>()
                .HasOne(t => t.UserRole)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.UserRoleID);

            // SUPPLIERS AND SUPPLIER REPRESENTATIVES

            modelBuilder.Entity<Suppliers>()
                .HasOne(t => t.SupplierRepresentative)
                .WithMany(g => g.Suppliers)
                .HasForeignKey(u => u.RepresentativeID);

            // PRODUCTS AND PRODUCT CATEGORIES

            modelBuilder.Entity<Products>()
           .HasOne(p => p.ProductCategory)  
           .WithMany(c => c.Products)      
           .HasForeignKey(p => p.CategoryID) 
           .OnDelete(DeleteBehavior.Restrict); 

            // PRODUCTS AND SUPPLIERS

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Supplier)        
                .WithMany(s => s.Products)      
                .HasForeignKey(p => p.SuppliersID) 
                .OnDelete(DeleteBehavior.SetNull);

        }
    }

}
