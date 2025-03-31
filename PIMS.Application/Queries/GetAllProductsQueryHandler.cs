using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }

    public class GetAllProductsQueryHandler(IProductRepository repository)
        : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllProductsAsync(cancellationToken);
        }
    }
}