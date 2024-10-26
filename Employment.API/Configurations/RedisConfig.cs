using StackExchange.Redis;

namespace Employment.API.Configurations
{
    public static class RedisConfig
    {
        public static IServiceCollection AddRedisConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IConnectionMultiplexer>(x =>
            {
                string connection = configuration.GetConnectionString("Redis")!;
                return ConnectionMultiplexer.Connect(connection);
            });

            return services;
        }
    }
}
