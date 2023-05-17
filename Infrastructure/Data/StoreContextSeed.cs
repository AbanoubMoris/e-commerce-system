using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task seedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
     
            }
            if (!context.ProductTypes.Any())
            {
                var Data = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(Data);
                context.ProductTypes.AddRange(types);
            }
            if (!context.Products.Any())
            {
                var Data = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(Data);
                context.Products.AddRange(products);
            }
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

        }

    }
}
