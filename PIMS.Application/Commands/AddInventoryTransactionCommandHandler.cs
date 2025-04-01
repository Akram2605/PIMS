using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Enums;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class AddInventoryTransactionCommand : IRequest<InventoryTransaction>
    {
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public string Reason { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }

    public class AddInventoryTransactionCommandHandler(IInventoryTransactionRepository repository)
        : IRequestHandler<AddInventoryTransactionCommand, InventoryTransaction>
    {
        public async Task<InventoryTransaction> Handle(AddInventoryTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new InventoryTransaction
            {
                InventoryId = request.InventoryId,
                Quantity = request.Quantity,
                Type = request.Type,
                Reason = request.Reason,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow
            };

            return await repository.AddAsync(transaction);
        }
    }
}