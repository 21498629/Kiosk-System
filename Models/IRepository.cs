using Kiosk.Models.User;
using Kiosk.Models.Inventory;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

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

        // USER  ROLES
        

        // INVENTORY

        // PRODUCTS
        Task<Products[]> GetAllProductsAsync();
        Task<Products> GetProductAsync(int productID);
        Task<Products[]> GetProductsByCategoryAsync(int categoryID);
        Task<ProductCategories[]> GetAllProductCategoriesAsync();
        Task<ProductCategories> GetProductCategoryAsync(int productCategoryID);

        // SUPPLIERS
        Task<Suppliers[]> GetAllSuppliersAsync();
        Task<Suppliers> GetSupplierAsync(int supplierID);
        Task<SupplierRepresentatives[]> GetAllSupplierRepresentativesAsync();
        Task<SupplierRepresentatives> GetSupplierRepresentativeAsync(int representativeID);

    }
}
