using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IPriceAdjustmentRepository
{
    Task<IEnumerable<PriceAdjustment>> GetAllAsync();
    Task<PriceAdjustment?> GetByIdAsync(Guid id);
    Task<PriceAdjustment> AddAsync(PriceAdjustment adjustment);
}