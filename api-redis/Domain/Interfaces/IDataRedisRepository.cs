namespace Domain.Interfaces;
public interface IDataRedisRepository
{
    Task AddDataAsync(RedisData data);
    Task<RedisData?> GetDataAsync(string id);
    // Task<IEnumerable<RedisData>> GetAllDataAsync();
}