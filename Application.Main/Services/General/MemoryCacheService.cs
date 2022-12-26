namespace Application.Main.Servicios.Entidades
{
    using Application.Main.Servicios.Generico.Interfaces;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<MemoryCacheService> _logger;
        public MemoryCacheService(
            IMemoryCache cache, 
            ILogger<MemoryCacheService> logger
        ) 
        {
            _cache = cache;
            _logger = logger;
        }

        public void SaveDataCache<T>(T data, string key)
        {
            var dataExists = _cache.Get(key);
            if (dataExists is not null)
                _cache.Remove(key);

            _cache.Set(key, data);
        }

        public void RemoveDataCache(string key)
        {
            var dataExists = _cache.Get(key);
            if (dataExists is not null)
                _cache.Remove(key);
        }

        public object GetDataCache(string key)
        {
            return _cache.Get(key);
        }
    }
}
