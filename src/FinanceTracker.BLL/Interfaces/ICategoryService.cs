using FinanceTracker.Shared.Models.ApiModels;

namespace FinanceTracker.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadModel>> GetAllCategoriesAsync();
     
    }
}
