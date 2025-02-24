using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain;

namespace API.Conttrollers;

[Route("api/[controller]")]
[ApiController]
public class RedisDataController : ControllerBase
{
    private readonly IDataRedisRepository _redisRepository;

    public RedisDataController(IDataRedisRepository redisRepository)
    {
        _redisRepository = redisRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDataRedis(string id)
    {
        RedisData data = await _redisRepository.GetDataAsync(id);
        return data is null ? NotFound() : Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> AddDataRedis(RedisData data)
    {
        await _redisRepository.AddDataAsync(data);
        return CreatedAtAction(nameof(GetDataRedis), new { id = data.Id }, data);
    }

}