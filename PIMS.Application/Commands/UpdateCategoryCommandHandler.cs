using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateCategoryCommandHandler(ICategoryRepository repository)
        : IRequestHandler<UpdateCategoryCommand, bool>
    {
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repository.GetCategoryByCategoryIdAsync(request.Id,cancellationToken);
            if (category == null) return false;

            category.Name = request.Name;
            category.Description = request.Description;

            await repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}