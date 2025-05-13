using FinanceTracker.Api.Middleware;
using FinanceTracker.BLL;
using FinanceTracker.DAL;

namespace FinanceTracker.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.RegisterBLLDependencies(builder.Configuration);
            builder.Services.RegisterDALDependencies(builder.Configuration);

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorApp",
                    builder => builder.WithOrigins("https://localhost:7065")
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                await Seeder.SeedInitialDataAsync(scope);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler();
            app.UseHttpsRedirection();

            app.UseCors("AllowBlazorApp");
            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}
