using FinanceTracker.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository
{
    public class GenericRepository<T>(DbContext context) : IGenericRepository<T> where T : class
    {
        public async Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
