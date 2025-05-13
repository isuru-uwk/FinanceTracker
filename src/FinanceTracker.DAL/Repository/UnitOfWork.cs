using FinanceTracker.DAL.Db;
using FinanceTracker.DAL.Db.Entities;
using FinanceTracker.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repository
{
    public class UnitOfWork(FinanceTrackerDbContext context) : IUnitOfWork
    {
        private readonly FinanceTrackerDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private IGenericRepository<Transaction>? _transactions;

        public IGenericRepository<Transaction> Transactions =>
            _transactions ??= new GenericRepository<Transaction>(_context);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle logging or rethrow based on your needs
                throw new DbUpdateException("Error saving changes", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
