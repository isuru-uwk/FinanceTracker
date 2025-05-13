using System.Linq.Expressions;

namespace FinanceTracker.DAL.Repository.IRepository
{

    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
