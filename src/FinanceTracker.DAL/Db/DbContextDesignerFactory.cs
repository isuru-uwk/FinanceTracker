using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceTracker.DAL.Db
{
    public class FinanceTrackerDbContextFactory : IDesignTimeDbContextFactory<FinanceTrackerDbContext>
    {
        public FinanceTrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceTrackerDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FinanceTrackerDev;Integrated Security=True; TrustServerCertificate=True");

            return new FinanceTrackerDbContext(optionsBuilder.Options);
        }
    }
}
