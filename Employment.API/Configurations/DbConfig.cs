using Employment.Persistence;
using Employment.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Employment.API.Configurations
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Database")!;

            services.AddSingleton<DBSavingChangesInterceptor>();

            services.AddDbContext<AppDbContext>(
                (sp, optionsBuilder) =>
                {
                    optionsBuilder.UseSqlServer(connectionString);
                    optionsBuilder.AddInterceptors(sp.GetRequiredService<DBSavingChangesInterceptor>());
                });

            return services;
        }
    }
}
