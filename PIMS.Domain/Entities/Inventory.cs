namespace PIMS.Domain.Entities;
public class Inventory : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public string WarehouseLocation { get; set; } = string.Empty;
    public int ThresholdLevel { get; set; } // For low inventory alerts
    public List<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();
}