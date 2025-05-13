using FinanceTracker.Shared.Enums;

namespace FinanceTracker.DAL.Db.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTimeOffset TransactionDate { get; set; }
        public string? Description { get; set; }
        public required TransactionType Type { get; set; }
        public required TransactionStatus Status { get; set; }

        // public required int CreatedBy { get; init; }
        public required DateTimeOffset CreatedDate { get; set; }
        //public required int ModifiedBy { get; set; }
        //public required DateTimeOffset ModifiedDate { get; set; }

        public required int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        //public required int UserId { get; init; }
        //public User User { get; set; } = default!;
    }
}
