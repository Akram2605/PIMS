using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.Domain.Entities;

namespace PIMS.Infrastructure.Configurations
{
    public class PriceAdjustmentConfiguration : IEntityTypeConfiguration<PriceAdjustment>
    {
        public void Configure(EntityTypeBuilder<PriceAdjustment> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.PreviousPrice)
                .HasPrecision(18, 2);

            builder.Property(pa => pa.NewPrice)
                .HasPrecision(18, 2);

            builder.Property(pa => pa.AdjustmentValue)
                .HasPrecision(18, 2);

            builder.Property(pa => pa.Reason)
                .HasMaxLength(250);

            builder.Property(pa => pa.UserId)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}