using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiStore.Data.Entities;

namespace MultiStore.Data.Config
{
    public class UnitMeasurementConfiguration : IEntityTypeConfiguration<UnitMeasurement>
    {
        public void Configure(EntityTypeBuilder<UnitMeasurement> builder)
        {
            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
