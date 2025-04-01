using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Queries
{
    public class GetCategoryByIdQuery(Guid id) : IRequest<Category?>
    {
        public Guid Id { get; set; } = id;
    }

    public class GetCategoryByIdQueryHandler(ICategoryRepository repository)
        : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetCategoryByCategoryIdAsync(request.Id, cancellationToken);
        }
    }
}