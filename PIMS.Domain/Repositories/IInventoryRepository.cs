using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IInventoryRepository
{
    public Task AddInventoryAsync(Inventory inventory, CancellationToken cancellationToken);
    
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<List<Inventory>> GetAllInventoriesAsync(CancellationToken cancellationToken);
    
    public Task<Inventory?> FindInventoryByInventoryIdAsync(Guid inventoryId, CancellationToken cancellationToken);
    
    public Task RemoveInventoryByIdAsync(Guid inventoryId, CancellationToken cancellationToken);
    
}