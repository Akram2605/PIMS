using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class CategoryRepository (PimsDbContext pimsDbContext) : ICategoryRepository
{
    public async Task<Category> AddCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        await pimsDbContext.Categories.AddAsync(category,cancellationToken);
        return category;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await pimsDbContext.Categories.ToListAsync( cancellationToken);
        return categories;
    }

    public async Task<Category?> GetCategoryByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var categories = await pimsDbContext.Categories.Where(p => p.Id == categoryId).SingleOrDefaultAsync(cancellationToken);
        return categories;
    }

    public async Task RemoveCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var category = await pimsDbContext.Categories.Include(c => c.Id == categoryId).SingleOrDefaultAsync(cancellationToken);

        if (category != null) pimsDbContext.Categories!.Remove(category);
    }
}