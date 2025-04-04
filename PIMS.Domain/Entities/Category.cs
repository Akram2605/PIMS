namespace PIMS.Domain.Entities;
public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}