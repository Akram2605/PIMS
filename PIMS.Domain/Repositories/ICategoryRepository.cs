using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface ICategoryRepository
{
    public Task AddCategoryAsync(Category category, CancellationToken cancellationToken);
    
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    
    public Task<Category?> FindCategoryByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);
    
    public Task RemoveCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken);

}