using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class ProductRepository (PimsDbContext pimsDbContext) : IProductRepository
{
    public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        await pimsDbContext.Products.AddAsync(product,cancellationToken);
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

    public async Task<Product?> FindProductByProductIdAsync(Guid productId, CancellationToken cancellationToken)
    { 
        var product = await pimsDbContext.Products.Where(p => p.Id == productId).SingleOrDefaultAsync(cancellationToken: cancellationToken);
        return product;
    }

    public async Task RemoveProductByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await pimsDbContext.Products.Include(p => p.Id == productId).SingleOrDefaultAsync(cancellationToken);

        if (product != null) pimsDbContext.Products!.Remove(product);
    }
}