using AngularEcommerce.Entity;

namespace AngularEcommerce.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();

    }
}
