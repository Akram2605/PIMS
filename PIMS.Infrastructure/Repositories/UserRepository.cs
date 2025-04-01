using Microsoft.EntityFrameworkCore;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;
using PIMS.Infrastructure.DbContexts;

namespace PIMS.Infrastructure.Repositories;

public class UserRepository(PimsDbContext pimsDbContext) : IUserRepository
{
    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await pimsDbContext.Users.AddAsync(user,cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<User>> GetAllUsersAsync( CancellationToken cancellationToken)
    {
        return await pimsDbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await pimsDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> FindUserByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await pimsDbContext.Users.Where(u => u.Id == userId) 
            .Include(u => u.Role)        
            .SingleOrDefaultAsync();
        return user;
    }

    public async Task RemoveUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await pimsDbContext.Users.Include(u => u.Id == userId).SingleOrDefaultAsync(cancellationToken);

        if (user != null) pimsDbContext.Users!.Remove(user);
        await pimsDbContext.SaveChangesAsync(cancellationToken);
    }
}