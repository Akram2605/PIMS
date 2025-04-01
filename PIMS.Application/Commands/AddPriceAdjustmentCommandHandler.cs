using MediatR;
using PIMS.Domain.Entities;
using PIMS.Domain.Enums;
using PIMS.Domain.Repositories;

namespace PIMS.Application.Commands
{
    public class AddPriceAdjustmentCommand : IRequest<PriceAdjustment>
    {
        public Guid ProductId { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal AdjustmentValue { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public string Reason { get; set; } = string.Empty;
        public Guid UserId { get; set; } 
    }

    public class AddPriceAdjustmentCommandHandler : IRequestHandler<AddPriceAdjustmentCommand, PriceAdjustment>
    {
        private readonly IPriceAdjustmentRepository _repository;

        public AddPriceAdjustmentCommandHandler(IPriceAdjustmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PriceAdjustment> Handle(AddPriceAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var adjustment = new PriceAdjustment
            {
                ProductId = request.ProductId,
                PreviousPrice = request.PreviousPrice,
                NewPrice = request.NewPrice,
                AdjustmentValue = request.AdjustmentValue,
                AdjustmentType = request.AdjustmentType,
                Reason = request.Reason,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow
            };

            return await _repository.AddAsync(adjustment);
        }
    }
}