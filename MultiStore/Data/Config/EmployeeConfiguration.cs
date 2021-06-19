using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiStore.Data.Entities;

namespace MultiStore.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(b => b.IdentityCard)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.HasIndex(b => b.IdentityCard)
                .IsUnique()
                .IsClustered(false);

            builder.Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.DateOfBirth)
                .HasColumnType("date");
        }
    }
}
