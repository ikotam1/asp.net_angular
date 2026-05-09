using Application.Common.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

public class MemoryCache : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<T?> GetAsync<T>(string key)
    {
        if (_cache.TryGetValue(key, out T? value))
        {
            return Task.FromResult<T?>(value);
        }

        return Task.FromResult<T?>(default(T?));
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }

    public Task SetAsync<T>(string key, T value, CacheOption options)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions();

        if (options.AbsoluteExpirationRelativeToNow.HasValue)
        {
            cacheEntryOptions.AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow.Value;
        }

        if (options.SlidingExpiration.HasValue)
        {
            cacheEntryOptions.SlidingExpiration = options.SlidingExpiration.Value;
        }

        _cache.Set(key, value, cacheEntryOptions);
        return Task.CompletedTask;
    }
}
