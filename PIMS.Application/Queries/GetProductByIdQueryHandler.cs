using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetProductByIdQuery(Guid id) : IRequest<Product?>
    {
        public Guid Id { get; set; } = id;
    }

    public class GetProductByIdQueryHandler(IProductRepository repository)
        : IRequestHandler<GetProductByIdQuery, Product?>
    {
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetProductByProductIdAsync(request.Id, cancellationToken);
        }
    }
}