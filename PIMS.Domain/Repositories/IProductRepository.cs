using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IProductRepository
{
    public Task AddProductAsync(Product product, CancellationToken cancellationToken);
    
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
    
    public Task<Product?> FindProductByProductIdAsync(Guid productId, CancellationToken cancellationToken);
    
    public Task RemoveProductByIdAsync(Guid productId, CancellationToken cancellationToken);

}