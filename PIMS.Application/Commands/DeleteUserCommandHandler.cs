using MediatR;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands;


public class DeleteUserCommand : IRequest<string>
{
    public Guid UserId { get; set; }
}

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, string>
{

    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindUserByUserIdAsync(request.UserId,cancellationToken);
        if (user == null) return "User not found";

        await userRepository.RemoveUserByIdAsync(request.UserId,cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return "User deleted successfully";
    }
}