using FinanceTracker.DAL.Db;
using FinanceTracker.DAL.Repository;
using FinanceTracker.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<FinanceTrackerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
