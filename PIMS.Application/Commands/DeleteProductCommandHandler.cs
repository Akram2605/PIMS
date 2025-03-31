using MediatR;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductCommandHandler(IProductRepository repository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveProductByIdAsync(request.Id, cancellationToken);
            return true;
        }
    }
}