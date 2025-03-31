using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class CreateProductCommandHandler(IProductRepository repository)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Sku = request.Sku,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

           var productId = await repository.AddProductAsync(product, cancellationToken);
           await repository.SaveChangesAsync(cancellationToken);
            return productId;
            
        }
    }
}