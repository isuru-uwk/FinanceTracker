using FinanceTracker.Shared.Enums;

namespace FinanceTracker.DAL.Db.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required TransactionType Type { get; set; }
        public required string? Icon { get; set; }
        public required bool IsActive { get; set; } = true;
        public required bool PreDefined { get; set; } = true;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        public ICollection<Transaction> Transactions { get; set; } = [];

    }
}
