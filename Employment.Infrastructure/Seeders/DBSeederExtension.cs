using Employment.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.Infrastructure.Seeders
{
    public static class DBSeederExtension
    {
        public static async Task<IServiceCollection> AddDBSeederExtension(this IServiceCollection services)
        {
            services.AddScoped<ISeeder, RolesSeeder>();
            services.AddScoped<ISeeder, CompanySeeder>();

            using var serviceProvider = services.BuildServiceProvider();

            var seeders = serviceProvider.GetServices<ISeeder>();

            seeders = seeders.OrderBy(x => x.ExecutionOrder);

            foreach (var seeder in seeders)
                await seeder.SeedAsync();

            return services;
        }
    }
}
