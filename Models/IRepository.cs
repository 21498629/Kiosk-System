using Kiosk.Models.User;
using Kiosk.Models.Inventory;

namespace Kiosk.Models
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // USER
        Task<Users[]> GetAllUsersAsync();
        Task<Users> GetUserAsync(int userID);
        Task<UserRoles[]> GetAllUserRolesAsync();
        Task<UserRoles> GetUserRoleAsync(int roleID);

        // INVENTORY

        // PRODUCTS
        Task<Products[]> GetAllProductsAsync();
        Task<Products> GetProductAsync(int productID);
        Task<ProductCategories[]> GetAllProductCategoriesAsync();
        Task<ProductCategories> GetProductCategoryAsync(int productCategoryID);

        // SUPPLIERS
        Task<Suppliers[]> GetAllSuppliersAsync();
        Task<Suppliers> GetSupplierAsync(int supplierID);
        Task<SupplierRepresentatives[]> GetAllSupplierRepresentativesAsync();
        Task<SupplierRepresentatives> GetSupplierRepresentativeAsync(int representativeID);

    }
}
