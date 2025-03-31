using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class InventoryTransactionRepository(PimsDbContext pimsDbContext) : IInventoryTransactionRepository
{
    public async Task<IEnumerable<InventoryTransaction>> GetAllAsync()
    {
        return await pimsDbContext.InventoryTransactions
            .Include(t => t.Inventory)
            .ToListAsync();
    }

    public async Task<InventoryTransaction?> GetByIdAsync(Guid id)
    {
        return await pimsDbContext.InventoryTransactions
            .Include(t => t.Inventory)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<InventoryTransaction> AddAsync(InventoryTransaction transaction)
    {
        pimsDbContext.InventoryTransactions.Add(transaction);
        await pimsDbContext.SaveChangesAsync();
        return transaction;
    }
}