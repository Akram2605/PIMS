using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.Domain.Entities;

namespace PIMS.Infrastructure.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.WarehouseLocation)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(i => i.Transactions)
                .WithOne(it => it.Inventory)
                .HasForeignKey(it => it.InventoryId);
        }
    }
}