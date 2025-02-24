using System.Text.Json;
using StackExchange.Redis;
using Domain;


namespace Infrastucture.Repositories;
public class DataRedisRepository : Domain.Interfaces.IDataRedisRepository
{
    private readonly IDatabase _redis;
    public DataRedisRepository(IConnectionMultiplexer redis)
    {
        _redis = redis.GetDatabase();
    }
    public async Task AddDataAsync(RedisData data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        await _redis.StringSetAsync(data.Id, jsonData);
    }
    public async Task<RedisData?> GetDataAsync(string id){
        var data = await _redis.StringGetAsync(id);
        Console.WriteLine(data);
        return data.HasValue ? JsonSerializer.Deserialize<RedisData>(data.ToString()) : null;
    }
}