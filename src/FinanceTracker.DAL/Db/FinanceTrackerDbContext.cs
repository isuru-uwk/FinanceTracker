using FinanceTracker.DAL.Db.Configurations;
using FinanceTracker.DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Db
{
    public class FinanceTrackerDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(nameof(modelBuilder));
            //base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }

    }
}
