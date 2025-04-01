using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CreateCategoryCommandHandler(ICategoryRepository repository)
        : IRequestHandler<CreateCategoryCommand, Category>
    {
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            return await repository.AddCategoryAsync(category, cancellationToken);
        }
    }
}