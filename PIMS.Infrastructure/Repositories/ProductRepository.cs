using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class ProductRepository (PimsDbContext pimsDbContext) : IProductRepository
{
    public async Task<Guid> AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        await pimsDbContext.Products.AddAsync(product,cancellationToken);
        return product.Id;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
       var products = await pimsDbContext.Products.ToListAsync( cancellationToken);
       return products;
    }

    public async Task<Product?> GetProductByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    { 
        var product = await pimsDbContext.Products.Where(p => p.Id == productId).SingleOrDefaultAsync( cancellationToken);
        return product;
    }

    public async Task RemoveProductByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await pimsDbContext.Products.Where(p => p.Id == productId).SingleOrDefaultAsync( cancellationToken);

        if (product != null)
        {
            pimsDbContext.Products!.Remove(product);
        }
    }
}