using FinanceTracker.DAL.Db;
using FinanceTracker.DAL.Db.Entities;
using FinanceTracker.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.DAL
{
    public static class Seeder
    {
        public static async Task SeedInitialDataAsync(IServiceScope scope)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();
            await dbContext.Database.MigrateAsync();
            await SeedTransactionsAsync(dbContext);
        }
        public static async Task SeedTransactionsAsync(FinanceTrackerDbContext context)
        {
            if (!await context.Transactions.AnyAsync())
            {
                var transactions = new List<Transaction>{
                new()
                {
                    Amount = 5000.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-10),
                    Description = "Monthly Salary",
                    Type = TransactionType.Income,
                    Status = TransactionStatus.Completed
                },
                new()
                {
                    Amount = 120.75m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    Description = "Grocery shopping at SuperMart",
                    Type = TransactionType.Expense,
                    Status = TransactionStatus.Completed
                }
            };

                context.Transactions.AddRange(transactions);
                await context.SaveChangesAsync();
            }
        }
    }
}
