using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetAllInventoryTransactionsQuery : IRequest<IEnumerable<InventoryTransaction>> { }

    public class GetAllInventoryTransactionsQueryHandler(IInventoryTransactionRepository repository)
        : IRequestHandler<GetAllInventoryTransactionsQuery, IEnumerable<InventoryTransaction>>
    {
        public async Task<IEnumerable<InventoryTransaction>> Handle(GetAllInventoryTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync();
        }
    }
}