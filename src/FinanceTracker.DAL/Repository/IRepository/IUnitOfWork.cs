using FinanceTracker.DAL.Db.Entities;

namespace FinanceTracker.DAL.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Transaction> Transactions { get; }
        Task<int> SaveChangesAsync();
    }
}
