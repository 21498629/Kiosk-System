using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public List<SupplierRepresentatives> SupplierRepresentatives { get; set; } = new List<SupplierRepresentatives>();
        //public List<Products> Products { get; set; } = new List<Products>();
    }
}
