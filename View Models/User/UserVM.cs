using Kiosk.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.User
{
    public class UserVM
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string PhysicalAddress { get; set; }
        public string Password { get; set; }
        public DateTime SignupDate { get; set; }
        public string Token { get; set; }
        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
    }
}
