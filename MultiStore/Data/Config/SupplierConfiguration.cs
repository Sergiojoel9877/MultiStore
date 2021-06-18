using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiStore.Data.Entities;

namespace MultiStore.Data.Config
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(b => b.NationalTaxPayerRegistry)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.HasIndex(b => b.NationalTaxPayerRegistry)
                .IsUnique()
                .IsClustered();

            builder.Property(b => b.CommercialName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
