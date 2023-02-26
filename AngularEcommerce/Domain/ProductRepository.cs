using AngularEcommerce.Data;
using AngularEcommerce.Entity;
using AngularEcommerce.Interface;
using Microsoft.EntityFrameworkCore;

namespace AngularEcommerce.Domain
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync()
        {
            return await _context.ProductsBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _context.Products.
                Include(p => p.ProductType)
                .Include(P => P.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(P => P.ProductBrand).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
