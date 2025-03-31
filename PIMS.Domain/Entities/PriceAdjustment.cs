using PIMS.Domain.Enums;

namespace PIMS.Domain.Entities;

public class PriceAdjustment : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public decimal PreviousPrice { get; set; }
    public decimal NewPrice { get; set; }
    public decimal AdjustmentValue { get; set; }
    public AdjustmentType AdjustmentType { get; set; }
    public string Reason { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}