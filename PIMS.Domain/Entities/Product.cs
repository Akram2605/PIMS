namespace PIMS.Domain.Entities;

public class Product : BaseEntity
{
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public List<Inventory> Inventories { get; set; } = new List<Inventory>();
}