using System.ComponentModel.DataAnnotations;

namespace Kiosk.View_Models.Inventory
{
    public class SupplierRepresentativesVM
    {
        public int RepresentativeID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
