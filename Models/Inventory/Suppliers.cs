using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Kiosk.Models.User;

namespace Kiosk.Models.Inventory
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email_Address { get; set; }
        public string? Physical_Address { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<Products> Products { get; set; } = new List<Products>();

        [Required]
        public int RepresentativeID { get; set; }

        [ForeignKey("RepresentativeID")]
        public SupplierRepresentatives SupplierRepresentative { get; set; }
    }
}
