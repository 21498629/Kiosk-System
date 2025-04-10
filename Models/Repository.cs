using Kiosk.Models.User;
using Kiosk.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Saving Changes
        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
        
        // Adding data
        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        // Deleting Data
        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        // USER
        public async Task<Users[]> GetAllUsersAsync()
        {
            IQueryable<Users> query = _appDbContext.User;
            return await query.ToArrayAsync();
        }
        public async Task<Users> GetUserAsync(int userID)
        {
            IQueryable<Users> query = _appDbContext.User;
            return await query.FirstOrDefaultAsync();
        }
        public async Task<UserRole[]> GetAllUserRolesAsync()
        {
            IQueryable<UserRole> query = _appDbContext.UserRole;
            return await query.ToArrayAsync();
        }
        public async Task<UserRole> GetUserRoleAsync(int roleID)
        {
            IQueryable<UserRole> query = _appDbContext.UserRole;
            return await query.FirstOrDefaultAsync();
        }

        // INVENTORY

        // PRODUCTS
        public async Task<ProductCategories[]> GetAllProductCategoriesAsync()
        {
            IQueryable<ProductCategories> query = _appDbContext.ProductCategories;
            return await query.ToArrayAsync();
        }
        public async Task<ProductCategories> GetProductCategoryAsync(int categoryID)
        {
            IQueryable<ProductCategories> query = _appDbContext.ProductCategories.Where(p => p.CategoryID == categoryID);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Products[]> GetAllProductsAsync()
        {
            IQueryable<Products> query = _appDbContext.Products;
            return await query.ToArrayAsync();
        }
        public async Task<Products> GetProductAsync(int productID)
        {
            IQueryable<Products> query = _appDbContext.Products.Where(p => p.ProductID == productID);
            return await query.FirstOrDefaultAsync();
        }

        // SUPPLIERS
        public async Task<Suppliers[]> GetAllSuppliersAsync()
        {
            IQueryable<Suppliers> query = _appDbContext.Suppliers;
            return await query.ToArrayAsync();
        }
        public async Task<Suppliers> GetSupplierAsync(int supplierID)
        {
            IQueryable<Suppliers> query = _appDbContext.Suppliers.Where(p => p.SupplierID == supplierID);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<SupplierRepresentatives[]> GetAllSupplierRepresentativesAsync()
        {
            IQueryable<SupplierRepresentatives> query = _appDbContext.SupplierRepresentatives;
            return await query.ToArrayAsync();
        }
        public async Task<SupplierRepresentatives> GetSupplierRepresentativeAsync(int representativeID)
        {
            IQueryable<SupplierRepresentatives> query = _appDbContext.SupplierRepresentatives.Where(p => p.RepresentativeID == representativeID);
            return await query.FirstOrDefaultAsync();
        }

    }
}
