using FinanceTracker.Shared.Models.ApiModels;
using System.Net.Http.Json;
using static FinanceTracker.Shared.Contants;

namespace FinanceTracker.App.Services
{
    public interface ITransactionApiService
    {
        Task<IReadOnlyCollection<TransactionReadModel>?> GetTransactionsAsync();
        Task<TransactionReadModel?> GetTransactionAsync(int transactionId);
        Task<bool> CreateTransactionAsync(TransactionWriteModel writeModel);
        Task<bool> UpdateTransactionAsync(TransactionWriteModel writeModel);
        Task<bool> DeleteTransactionAsync(int transactionId);
    }

    public class TransactionApiService(HttpClient httpClient) : ITransactionApiService
    {

        public async Task<IReadOnlyCollection<TransactionReadModel>?> GetTransactionsAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IReadOnlyCollection<TransactionReadModel>>(ApiEndpoints.Transactions);
            return result;
        }

        public async Task<TransactionReadModel?> GetTransactionAsync(int transactionId)
        {
            return await httpClient.GetFromJsonAsync<TransactionReadModel>($"{ApiEndpoints.Transactions}/{transactionId}");
        }

        public async Task<bool> CreateTransactionAsync(TransactionWriteModel writeModel)
        {
            var response = await httpClient.PostAsJsonAsync(ApiEndpoints.Transactions, writeModel);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTransactionAsync(TransactionWriteModel writeModel)
        {
            var response = await httpClient.PutAsJsonAsync($"{ApiEndpoints.Transactions}/{writeModel.TransactionId}", writeModel);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var response = await httpClient.DeleteAsync($"{ApiEndpoints.Transactions}/{transactionId}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;

        }
    }

}
