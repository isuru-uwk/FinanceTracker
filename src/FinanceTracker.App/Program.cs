using FinanceTracker.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace FinanceTracker.App
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7182/") });
            builder.Services.AddScoped<ITransactionApiService, TransactionApiService>();
            builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
