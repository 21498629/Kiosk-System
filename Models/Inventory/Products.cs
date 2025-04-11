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
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public ProductCategories ProductCategory { get; set; }

        //[Required]
        public int? SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public Suppliers Supplier { get; set; }
    }
}
