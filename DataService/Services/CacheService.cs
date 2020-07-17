using Microsoft.Extensions.Caching.Memory;
using Petbase.DataService.Interfaces;

namespace Petbase.DataService.Services
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
            object token;
           
            if (cache.TryGetValue(key, out token))
            {
                return token;
            }
            return null;        
        }

        public void SaveCache(object key, object value)
        {
            this.cache.Set(key, value);
        }
    }
}
