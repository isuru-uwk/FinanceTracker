using FinanceTracker.DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DAL.Db.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("Category");

            builder.HasKey(t => t.CategoryId)
                .IsClustered();

            builder.Property(e => e.Name)
                .HasMaxLength(512);

            builder.Property(e => e.Icon)
                .HasMaxLength(64);

            builder.Property(e => e.Icon)
                .HasMaxLength(64);
        }
    }


}
