using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk.Models.Inventory
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty ;
        [Required]
        [Column(TypeName = " decimal(5, 2")]
        public decimal Price { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public List<Suppliers> Suppliers { get; set; } = new List<Suppliers>();
        public List<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();
    }
}
