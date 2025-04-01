using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class InventoryRepository(PimsDbContext pimsDbContext) : IInventoryRepository
{
    public async Task<Inventory> AddInventoryAsync(Inventory inventory, CancellationToken cancellationToken)
    {
        await pimsDbContext.Inventories.AddAsync(inventory,cancellationToken);
        return inventory;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Inventory>> GetAllInventoriesAsync(CancellationToken cancellationToken)
    {
        var inventories = await pimsDbContext.Inventories.ToListAsync( cancellationToken);
        return inventories;
    }

    public async Task<Inventory?> FindInventoryByInventoryIdAsync(Guid inventoryId, CancellationToken cancellationToken)
    {
        var inventory = await pimsDbContext.Inventories.Where(i => i.Id == inventoryId).SingleOrDefaultAsync(cancellationToken);
        return inventory;
    }

    public async Task RemoveInventoryByIdAsync(Guid inventoryId, CancellationToken cancellationToken)
    {
        var inventory = await pimsDbContext.Inventories.Where(i => i.Id == inventoryId).SingleOrDefaultAsync(cancellationToken);
        if (inventory != null) pimsDbContext.Inventories!.Remove(inventory);
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }
}