using FinanceTracker.BLL.Interfaces;
using FinanceTracker.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
