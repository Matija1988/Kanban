using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure.Caching;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;

    public RedisCacheService(IConnectionMultiplexer connection)
    {
        _db = connection.GetDatabase();
    }
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _db.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;
        return JsonSerializer.Deserialize<T>(value!);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var json = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, json, expiration);
    }

    public async Task RemoveByPatternAsync(string pattern)
    {
        var endpoints = _db.Multiplexer.GetEndPoints();
        foreach (var endpoint in endpoints)
        {
            var server = _db.Multiplexer.GetServer(endpoint);
            if (!server.IsConnected) continue;

            var keys = server.Keys(pattern: pattern).ToArray();

            if (keys.Length > 0)
            {
                await _db.KeyDeleteAsync(keys);
            }
        }
    }
}
