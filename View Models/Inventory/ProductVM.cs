using Kiosk.Models.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosk.View_Models.Inventory
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = " decimal(5, 2")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a postive value.")]
        public decimal Price { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please select an image")]
        public IFormFile ImageFile { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int SupplierID { get; set; }
    }
}
