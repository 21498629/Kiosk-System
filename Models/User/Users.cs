using Kiosk.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosk.Models.User

{
    [Table("Users")]
    public class Users : IdentityUser
    {
        
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhysicalAddress { get; set; }
        [Required]
        public DateTime SignupDate { get; set; }

        [Required]
        public int UserRoleID { get; set; }

        [ForeignKey("UserRoleID")]
        public UserRoles UserRole { get; set; }
    }
}
