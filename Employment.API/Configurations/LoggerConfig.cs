using Serilog;

namespace Employment.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddSerilogConfig(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithThreadId()
                .WriteTo.Console()
                .CreateLogger();

            return services;
        }

    }
}
