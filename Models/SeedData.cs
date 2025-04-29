using System.Net.NetworkInformation;
using System.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Kiosk.Models.User;

namespace Kiosk.Models
{
    public static class SeedData
    {
        public static class Roles
        {
            public static readonly IdentityRole Superuser = new IdentityRole
            {
                Id = "1",
                Name = "Superuser",
                NormalizedName = "SUPERUSER",
                ConcurrencyStamp = "kgbasdcsfv-dasdjgbf-ascfb"
            };
            public static readonly IdentityRole Admin = new IdentityRole
            {
                Id = "2",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "kjdbhszf-sdflobnljfc-fszdnvd"
            };
            public static readonly IdentityRole User = new IdentityRole
            {
                Id = "3",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "ljsdhfv-lkjbhdfs-kjbhdsueh"
            };

            public static List<IdentityRole> GetAllRoles() => new List<IdentityRole> { Superuser, Admin, User };

        }

        public static Users GetAdminUser()
        {
            return new Users
            {
                Id = "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9",
                Name = "Admin",
                Surname = "Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "0123456789",
                PhysicalAddress = "Admin",
                PasswordHash = null,
                SecurityStamp = "dheu48yu9jb sk-0efojrf-basdckj",
                ConcurrencyStamp = "judfs-dsfdkbfsde-fvsdjklbn"

            };
        }

        public static IdentityUserRole<string> GetAdminUserRole() 
        {
            return new IdentityUserRole<string>
            {
                UserId = "a4e5f6g7-8h9i-0j1k-2l3m-a4e5f6g7h8i9",
                RoleId = "1"
            };
        }
    }
}
    

