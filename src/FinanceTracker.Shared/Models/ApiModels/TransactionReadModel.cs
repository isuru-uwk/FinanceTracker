using FinanceTracker.Shared.Enums;

namespace FinanceTracker.Shared.Models.ApiModels
{
    public class TransactionReadModel
    {
        public required int TransactionId { get; init; }
        public required string Description { get; init; }
        public required decimal Amount { get; init; }
        public required DateTimeOffset TransactionDate { get; init; }
        public TransactionType Type { get; init; }
        public required int CategoryId { get; init; }
    }
}
