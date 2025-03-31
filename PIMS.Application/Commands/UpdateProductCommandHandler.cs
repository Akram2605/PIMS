using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class UpdateProductCommandHandler(IProductRepository repository)
        : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetProductByProductIdAsync(request.Id,cancellationToken);
            if (product == null) return false;

            product.Sku = request.Sku;
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}