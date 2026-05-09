using Application.Common.Caching;

namespace Infrastructure.Caching;

public class RedisCache : ICacheService
{
    public Task<T?> GetAsync<T>(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task SetAsync<T>(string key, T value, CacheOption options)
    {
        throw new NotImplementedException();
    }
}
