using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class UpdateInventoryCommand : IRequest<Inventory?>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string WarehouseLocation { get; set; } = string.Empty;
        public int ThresholdLevel { get; set; }
    }

    public class UpdateInventoryCommandHandler(IInventoryRepository repository)
        : IRequestHandler<UpdateInventoryCommand, Inventory?>
    {
        public async Task<Inventory?> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await repository.FindInventoryByInventoryIdAsync(request.Id, cancellationToken);
            if (inventory == null) return null;

            inventory.Quantity = request.Quantity;
            inventory.WarehouseLocation = request.WarehouseLocation;
            inventory.ThresholdLevel = request.ThresholdLevel;
            inventory.ModifiedDate = DateTime.UtcNow;

            await repository.SaveChangesAsync(cancellationToken);
            return inventory;
        }
    }
}