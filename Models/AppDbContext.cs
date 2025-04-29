using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Kiosk.Models.User;
using Kiosk.Models.Inventory;
using Microsoft.Extensions.Hosting;

namespace Kiosk.Models
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // INVENTORY
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SupplierRepresentatives> SupplierRepresentatives { get; set; }

        // USER
        public DbSet<Users> User { get; set; }
        //public DbSet<UserRoleVM> UserRole { get; set; }

        // FOERIGN KEY RELATIONSHIPS
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // SUPPLIERS AND SUPPLIER REPRESENTATIVES

            builder.Entity<Suppliers>()
                .HasOne(t => t.SupplierRepresentative)
                .WithMany(g => g.Suppliers)
                .HasForeignKey(u => u.RepresentativeID);

            // PRODUCTS AND PRODUCT CATEGORIES

            builder.Entity<Products>()
           .HasOne(p => p.ProductCategory)  
           .WithMany(c => c.Products)      
           .HasForeignKey(p => p.CategoryID) 
           .OnDelete(DeleteBehavior.Restrict);

            // PRODUCTS AND SUPPLIERS

            builder.Entity<Products>()
                .HasOne(p => p.Supplier)        
                .WithMany(s => s.Products)      
                .HasForeignKey(p => p.SupplierID) 
                .OnDelete(DeleteBehavior.SetNull);

            //  SEEDING DATA FOR USER ROLES

            builder.Entity<IdentityRole>().HasData(SeedData.Roles.GetAllRoles());

            // SEEDING ADMIN USER

            var hasher = new PasswordHasher<Users>();
            var adminUser = SeedData.GetAdminUser();
            adminUser.PasswordHash = hasher.HashPassword(null, "@dm1nAdmin");

            builder.Entity<Users>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(SeedData.GetAdminUserRole());

            /*builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Superuser",
                    NormalizedName = "SUPERUSER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }

            );

            //  SEEDING DATA FOR USERS
            var hasher = new PasswordHasher<Users>();
            builder.Entity<Users>().HasData(
                new Users
                {
                    Id = "1",
                    Name = "Admin",
                    Surname = "Admin",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    PhoneNumber = "0123456789",
                    PhysicalAddress = "Admin",
                    PasswordHash = hasher.HashPassword(null, "@dm1inAdmin"),
                    SecurityStamp = "dheu48yu9jb sk-0efojrf-basdckj",
                    ConcurrencyStamp = "judfs-dsfdkbfsde-fvsdjklbn"
                }
            );

            // SEED USER ROLES
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = 1.ToString(),
                    UserId = 1.ToString()
                }
            );*/
        }
    }

}
