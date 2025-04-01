using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetAllInventoriesQuery : IRequest<IEnumerable<Inventory>> { }

    public class GetAllInventoriesQueryHandler(IInventoryRepository repository)
        : IRequestHandler<GetAllInventoriesQuery, IEnumerable<Inventory>>
    {
        public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllInventoriesAsync(cancellationToken);
        }
    }
}