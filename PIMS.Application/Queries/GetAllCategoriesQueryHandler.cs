using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>> { }

    public class GetAllCategoriesQueryHandler(ICategoryRepository repository)
        : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllCategoriesAsync(cancellationToken);
        }
    }
}