using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class AddInventoryCommand : IRequest<Inventory>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string WarehouseLocation { get; set; } = string.Empty;
        public int ThresholdLevel { get; set; }
    }

    public class AddInventoryCommandHandler(IInventoryRepository repository)
        : IRequestHandler<AddInventoryCommand, Inventory>
    {
        public async Task<Inventory> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = new Inventory
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                WarehouseLocation = request.WarehouseLocation,
                ThresholdLevel = request.ThresholdLevel,
                CreatedDate = DateTime.UtcNow
            };

            return await repository.AddInventoryAsync(inventory, cancellationToken);
        }
    }
}