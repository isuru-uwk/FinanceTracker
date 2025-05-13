using AutoMapper;
using FinanceTracker.BLL.Interfaces;
using FinanceTracker.DAL.Db.Entities;
using FinanceTracker.DAL.Repository.IRepository;
using FinanceTracker.Shared.Models.ApiModels;

namespace FinanceTracker.BLL.Services
{
    internal class TransactionService(IUnitOfWork uow, IMapper mapper) : ITransactionService
    {
        public async Task<int> CreateTransactionAsync(TransactionWriteModel writeModel)
        {
            ValidateTransaction(writeModel);

            var requestModel = mapper.Map<Transaction>(writeModel);

            uow.Transactions.Add(requestModel);
            var transactionId = await uow.SaveChangesAsync();

            return transactionId;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var transaction = await uow.Transactions.GetAsync(t => t.TransactionId == transactionId);

            if (transaction == null)
                return false;

            uow.Transactions.Remove(transaction);
            await uow.SaveChangesAsync();

            return true;
        }

        public async Task<IReadOnlyCollection<TransactionReadModel>> GetAllTransactionsAsync()
        {
            var result = await uow.Transactions.GetAllAsync();
            return mapper.Map<IReadOnlyCollection<TransactionReadModel>>(result);
        }

        public async Task<TransactionReadModel> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await uow.Transactions.GetAsync(t => t.TransactionId == transactionId);

            return transaction == null
                ? throw new KeyNotFoundException($"Transaction with ID {transactionId} was not found.")
                : mapper.Map<TransactionReadModel>(transaction);
        }

        public async Task<bool> UpdateTransactionAsync(TransactionWriteModel writeModel)
        {
            ArgumentNullException.ThrowIfNull(writeModel);

            ValidateTransaction(writeModel);

            var existingTransaction = await uow.Transactions
                .GetAsync(t => t.TransactionId == writeModel.TransactionId) ?? throw new KeyNotFoundException("Transaction not found.");

            mapper.Map(writeModel, existingTransaction);
            uow.Transactions.Update(existingTransaction);

            var changes = await uow.SaveChangesAsync();
            return changes > 0;
        }

        private static void ValidateTransaction(TransactionWriteModel writeModel)
        {
            if(writeModel.TransactionDate > DateTimeOffset.UtcNow)
            {
                throw new InvalidOperationException("Transaction date cannot be a future date");
            }
        }
    }
}
