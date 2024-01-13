using Product.API.Entities;
using ILogger = Serilog.ILogger;

namespace Product.API.Persistence;

public class ProductContextSeed
{
    public static async Task SeedProductAsync(ProductContext context, ILogger logger)
    {
        try
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(getCatalogProducts());
                await context.SaveChangesAsync();
                logger.Information("Seed database associated with context {DbContextName}",
                    typeof(ProductContext).Name);
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Error occurred seeding the database associated with context {DbContextName}",
                typeof(ProductContext).Name);
        }
    }

    private static IEnumerable<CatalogProduct> getCatalogProducts()
    {
        return new List<CatalogProduct>
        {
            new()
            {
                No = "Lotus",
                Name = "Esprit",
                Summary = "Nondisplaced fracture of greater trochanter of right femur",
                Description = "Nondisplaced fracture of greater trochanter of right femur",
                Price = (decimal)177940.49,
            },
            new()
            {
                No = "Cadilac",
                Name = "CTS",
                Summary = "Carbuncle of trunk",
                Description = "Carbuncle of trunk",
                Price = (decimal)121231.49,
            },
        };
    }
}