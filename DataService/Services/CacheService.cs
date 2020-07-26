using Microsoft.Extensions.Caching.Memory;
using Petbase.DataService.Interfaces;
using System;

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

            cache.TryGetValue(key, out token);
                      
            return token;        
        }

        public void SaveCache(object key, object value, TimeSpan expireTime)
        {
            this.cache.Set(key, value, expireTime);
        }
    }
}
