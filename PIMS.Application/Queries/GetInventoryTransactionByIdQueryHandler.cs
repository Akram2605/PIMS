using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetInventoryTransactionByIdQuery : IRequest<InventoryTransaction?>
    {
        public Guid Id { get; set; }
    }

    public class GetInventoryTransactionByIdQueryHandler(IInventoryTransactionRepository repository)
        : IRequestHandler<GetInventoryTransactionByIdQuery, InventoryTransaction?>
    {
        public async Task<InventoryTransaction?> Handle(GetInventoryTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByIdAsync(request.Id);
        }
    }
}