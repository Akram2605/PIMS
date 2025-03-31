using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class PriceAdjustmentRepository (PimsDbContext pimsDbContext): IPriceAdjustmentRepository
{
    public async Task<IEnumerable<PriceAdjustment>> GetAllAsync()
    {
        return await pimsDbContext.PriceAdjustments
            .Include(pa => pa.Product)
            .ToListAsync();
    }

    public async Task<PriceAdjustment?> GetByIdAsync(Guid id)
    {
        return await pimsDbContext.PriceAdjustments
            .Include(pa => pa.Product)
            .FirstOrDefaultAsync(pa => pa.Id == id);
    }

    public async Task<PriceAdjustment> AddAsync(PriceAdjustment adjustment)
    {
        pimsDbContext.PriceAdjustments.Add(adjustment);
        await pimsDbContext.SaveChangesAsync();
        return adjustment;
    }
}