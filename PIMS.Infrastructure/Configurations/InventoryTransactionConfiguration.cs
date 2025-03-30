using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.Domain.Entities;

namespace PIMS.Infrastructure.Configurations
{
    public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
    {
        public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
        {
            builder.HasKey(it => it.Id);

            builder.Property(it => it.Quantity)
                .IsRequired();

            builder.Property(it => it.Reason)
                .HasMaxLength(250);

            builder.Property(it => it.UserId)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}