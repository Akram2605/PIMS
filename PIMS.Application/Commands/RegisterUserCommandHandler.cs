using MediatR;
using Microsoft.AspNetCore.Identity;
using PIMS.Domain.Entities;
using PIMS.Domain.Enums;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands;


public class RegisterUserCommand : IRequest<string>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
public class RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher): IRequestHandler<RegisterUserCommand, string>
{

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.Empty,
            UserName = request.UserName,
            Email = request.Email,
            Role = request.Role,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
        };

        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

        await userRepository.AddUserAsync(user,cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return "User registered successfully";
    }
    
}