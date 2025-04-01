using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetAllPriceAdjustmentsQuery : IRequest<IEnumerable<PriceAdjustment>> { }

    public class GetAllPriceAdjustmentsQueryHandler(IPriceAdjustmentRepository repository)
        : IRequestHandler<GetAllPriceAdjustmentsQuery, IEnumerable<PriceAdjustment>>
    {
        public async Task<IEnumerable<PriceAdjustment>> Handle(GetAllPriceAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync();
        }
    }
}