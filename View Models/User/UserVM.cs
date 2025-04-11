using Kiosk.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.User
{
    public class UserVM
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string Password { get; set; }
        public DateTime SignupDate { get; set; }
        public string Token { get; set; }

        [Required]
        public int UserRoleID { get; set; }
    }
}
