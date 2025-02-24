using Domain.Interfaces;
using Infrastucture.Repositories;
using StackExchange.Redis;

namespace Infrastucture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string redisConnectionString)
    {
        var redis = ConnectionMultiplexer.Connect(redisConnectionString);
        services.AddSingleton<IConnectionMultiplexer>(redis);
        services.AddScoped<IDataRedisRepository, DataRedisRepository>();
        return services;
    }
}