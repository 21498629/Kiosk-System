using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk.Models.User
{
    [Table("UserRoles")]
    public class UserRoles
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty ;

        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
