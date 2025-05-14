using FinanceTracker.DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DAL.Db.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("Transaction");

            builder.HasKey(t => t.TransactionId)
                .IsClustered();

            builder.Property(e => e.TransactionId)
                .HasColumnName("Transaction_ID");

            builder.Property(e => e.Description)
                .HasMaxLength(256);

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Category");

            //builder.HasOne(d => d.User)
            //    .WithMany(p => p.Transactions)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(false)
            //    .HasConstraintName("FK_Transaction_User");
        }
    }


}
