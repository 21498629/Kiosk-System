using Kiosk.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.Inventory
{
    public class SuppliersVM
    {
        public int SupplierID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email_Address { get; set; }
        public string? Physical_Address { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public List<SupplierRepresentatives> SupplierRepresentatives { get; set; } = new List<SupplierRepresentatives>();
    }
}
