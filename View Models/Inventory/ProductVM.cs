using Kiosk.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosk.View_Models.Inventory
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = " decimal(5, 2")]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public List<Suppliers> Suppliers { get; set; } = new List<Suppliers>();
        public List<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();
    }
}
