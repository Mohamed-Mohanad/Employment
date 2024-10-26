using Hangfire;

namespace Employment.API.Configurations
{
    public static class HangfireConfig
    {
        public static IServiceCollection AddHangfireConfig(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("Database")!;

            services.AddHangfire(config => config.UseSqlServerStorage(dbConnectionString));

            services.AddHangfireServer();

            return services;
        }

    }
}
