using AngularEcommerce.Entity;
using System.Text.Json;

namespace AngularEcommerce.Data
{
    public class StoreContextSeed
    {
        public static async Task SeesAsync(StoreContext context)
        {
            if(!context.ProductsBrands.Any()) 
            {
                var brandsData = File.ReadAllText("SeedData/brands.json");  
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductsBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
           

        }
    }
}
