using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetPriceAdjustmentByIdQuery : IRequest<PriceAdjustment?>
    {
        public Guid Id { get; set; }
    }

    public class GetPriceAdjustmentByIdQueryHandler(IPriceAdjustmentRepository repository)
        : IRequestHandler<GetPriceAdjustmentByIdQuery, PriceAdjustment?>
    {
        public async Task<PriceAdjustment?> Handle(GetPriceAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByIdAsync(request.Id);
        }
    }
}