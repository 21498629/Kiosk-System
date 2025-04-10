using Kiosk.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.Models.User
{
    public class Users : IdentityUser
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string PhysicalAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public DateTime SignupDate { get; set; }
        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
    }
}
