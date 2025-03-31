using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IProductRepository
{
    public Task<Guid> AddProductAsync(Product product, CancellationToken cancellationToken);
    
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
    
    public Task<Product?> GetProductByProductIdAsync(Guid productId, CancellationToken cancellationToken);
    
    public Task RemoveProductByIdAsync(Guid productId, CancellationToken cancellationToken);

}