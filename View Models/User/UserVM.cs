using Kiosk.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.User
{
    public class UserVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string PhysicalAddress { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime SignupDate { get; set; }
        public string Token { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}
