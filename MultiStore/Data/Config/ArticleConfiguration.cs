using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiStore.Data.Entities;

namespace MultiStore.Data.Config
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
