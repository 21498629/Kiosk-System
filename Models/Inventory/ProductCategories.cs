using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Kiosk.Models.User;

namespace Kiosk.Models.Inventory
{
    public class ProductCategories
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required] 
        public string Description { get; set; } = string.Empty;

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
