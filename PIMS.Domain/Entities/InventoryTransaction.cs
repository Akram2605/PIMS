using PIMS.Domain.Enums;

namespace PIMS.Domain.Entities;
public class InventoryTransaction : BaseEntity
{
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; } = null!;
    public int Quantity { get; set; }
    public TransactionType Type { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}