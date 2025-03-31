using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IInventoryTransactionRepository
{
    Task<IEnumerable<InventoryTransaction>> GetAllAsync();
    Task<InventoryTransaction?> GetByIdAsync(Guid id);
    Task<InventoryTransaction> AddAsync(InventoryTransaction transaction);
}