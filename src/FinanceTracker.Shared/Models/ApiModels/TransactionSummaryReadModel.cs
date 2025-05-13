namespace FinanceTracker.Shared.Models.ApiModels
{
    public class TransactionSummaryReadModel
    {
        public required decimal TotalIncome { get; init; }
        public required decimal TotalExpenses { get; init; }
        public required decimal Savings { get; init; }
    }
}
