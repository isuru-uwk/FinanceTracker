using AutoMapper;
using FinanceTracker.BLL.Interfaces;
using FinanceTracker.DAL.Repository.IRepository;
using FinanceTracker.Shared.Models.ApiModels;

namespace FinanceTracker.BLL.Services
{
    internal class CategoryService(IUnitOfWork uow, IMapper mapper) : ICategoryService
    {
        public async Task<IEnumerable<CategoryReadModel>> GetAllCategoriesAsync()
        {
            var result = await uow.Categories.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryReadModel>>(result);
        }
    }
}
