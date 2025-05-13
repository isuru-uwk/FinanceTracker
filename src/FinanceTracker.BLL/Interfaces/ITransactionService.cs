using FinanceTracker.Shared.Models.ApiModels;

namespace FinanceTracker.BLL.Interfaces
{
    public interface ITransactionService
    {
        Task<IReadOnlyCollection<TransactionReadModel>> GetAllTransactionsAsync();
        Task<TransactionReadModel> GetTransactionByIdAsync(int transactionId);
        Task<int> CreateTransactionAsync(TransactionWriteModel writeModel);
        Task<bool> UpdateTransactionAsync(TransactionWriteModel writeModel);
        Task<bool> DeleteTransactionAsync(int transactionId);   
    }
}
