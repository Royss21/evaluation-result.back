namespace Application.Main.Servicios.Generico.Interfaces
{
    public interface IMemoriaCacheServicio
    {
        void GuardarDatoCache<T>(T data, string key);
        void RemoverDatoCache(string key);
        object ObtenerDatoCache(string key);
    }
}
