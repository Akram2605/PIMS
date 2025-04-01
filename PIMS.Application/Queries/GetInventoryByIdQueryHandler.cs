using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetInventoryByIdQuery : IRequest<Inventory?>
    {
        public Guid Id { get; set; }
    }

    public class GetInventoryByIdQueryHandler(IInventoryRepository repository)
        : IRequestHandler<GetInventoryByIdQuery, Inventory?>
    {
        public async Task<Inventory?> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.FindInventoryByInventoryIdAsync(request.Id, cancellationToken);
        }
    }
}