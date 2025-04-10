using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.User
{
    public class LoginVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
