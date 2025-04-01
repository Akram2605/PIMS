using MediatR;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class DeleteInventoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInventoryCommandHandler(IInventoryRepository repository)
        : IRequestHandler<DeleteInventoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveInventoryByIdAsync(request.Id, cancellationToken);
            return true;
        }
    }
}