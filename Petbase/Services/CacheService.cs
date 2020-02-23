using DataService.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Petbase.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache memoryCache)
        {
            this.cache = memoryCache;
        }

        public object GetCache(object key) 
        {
            return this.cache.Get(key);
        }

        public void SaveCache(object key, object value)
        {
            this.cache.Set(key, value);
        }
    }
}
