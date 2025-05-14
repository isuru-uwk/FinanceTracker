using FinanceTracker.Shared.Models.ApiModels;
using System.Net.Http.Json;
using static FinanceTracker.Shared.Contants;

namespace FinanceTracker.App.Services
{
    public interface ICategoryApiService
    {
        Task<IEnumerable<CategoryReadModel>?> GetCategoriesAsync();

    }
    public class CategoryApiService(HttpClient httpClient) : ICategoryApiService
    {
        public async Task<IEnumerable<CategoryReadModel>?> GetCategoriesAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CategoryReadModel>>(ApiEndpoints.Categories);
            return result;
        }

    }
}
