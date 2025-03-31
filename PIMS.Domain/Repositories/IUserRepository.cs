using PIMS.Domain.Entities;

namespace PIMS.Domain.Repositories;

public interface IUserRepository
{
    public Task AddUserAsync(User user, CancellationToken cancellationToken);
    
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken);
    
    public Task<User?> FindUserByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
    public Task RemoveUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    
}