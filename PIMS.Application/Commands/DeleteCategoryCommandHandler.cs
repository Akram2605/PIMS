using MediatR;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler(ICategoryRepository repository)
        : IRequestHandler<DeleteCategoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveCategoryByIdAsync(request.Id, cancellationToken);
            return true;
        }
    }
}