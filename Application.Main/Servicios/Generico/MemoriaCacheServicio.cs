namespace Application.Main.Servicios.Entidades
{
    using Application.Main.Servicios.Generico.Interfaces;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class MemoriaCacheServicio : IMemoriaCacheServicio
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<MemoriaCacheServicio> _logger;
        public MemoriaCacheServicio(
            IMemoryCache cache, 
            ILogger<MemoriaCacheServicio> logger
        ) 
        {
            _cache = cache;
            _logger = logger;
        }

        public void GuardarDatoCache<T>(T data, string key)
        {
            var dataExistente = _cache.Get(key);
            if (dataExistente is not null)
                _cache.Remove(key);

            _cache.Set(key, data);
        }

        public void RemoverDatoCache(string key)
        {
            var dataExistente = _cache.Get(key);
            if (dataExistente is not null)
                _cache.Remove(key);
        }

        public object ObtenerDatoCache(string key)
        {
            return _cache.Get(key);
        }
    }
}
