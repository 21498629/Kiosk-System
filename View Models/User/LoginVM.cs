using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.User
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
