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
            await SeedCategoriesAsync(dbContext);
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
                    Status = TransactionStatus.Completed,
                    CategoryId = 1,
                    CreatedDate = DateTimeOffset.UtcNow
                },
                new()
                {
                    Amount = 120.75m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    Description = "Grocery shopping at SuperMart",
                    Type = TransactionType.Expense,
                    Status = TransactionStatus.Completed,
                    CategoryId = 2,
                    CreatedDate = DateTimeOffset.UtcNow
                }
            };

                context.Transactions.AddRange(transactions);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCategoriesAsync(FinanceTrackerDbContext context)
        {
            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category> {
                    new() {
                            Name = "Housing",
                            Type = TransactionType.Expense,
                            Icon = "🏠",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Transportation",
                            Type = TransactionType.Expense,
                            Icon = "🚗",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Groceries",
                            Type = TransactionType.Expense,
                            Icon = "🛒",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Dining Out",
                            Type = TransactionType.Expense,
                            Icon = "🍽️",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Subscriptions",
                            Type = TransactionType.Expense,
                            Icon = "📱",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },

                    // Income Categories
                    new() {
                            Name = "Salary",
                            Type = TransactionType.Income,
                            Icon = "💼",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Investments",
                            Type = TransactionType.Income,
                            Icon = "📈",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Freelancing / Side Hustles",
                            Type = TransactionType.Income,
                            Icon = "🧾",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Gifts / Bonuses",
                            Type = TransactionType.Income,
                            Icon = "🎁",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    },
                    new() {
                            Name = "Interest / Dividends",
                            Type = TransactionType.Income,
                            Icon = "🏦",
                            IsActive = true,
                            PreDefined = true,
                            CreatedDate = DateTimeOffset.UtcNow
                    }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}
