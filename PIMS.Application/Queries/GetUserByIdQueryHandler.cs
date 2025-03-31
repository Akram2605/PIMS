using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries;


public class GetUserByIdQuery : IRequest<User>
{
    public Guid UserId { get; set; }
}

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, User>
{

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await userRepository.FindUserByUserIdAsync(request.UserId, cancellationToken);;
    }
}