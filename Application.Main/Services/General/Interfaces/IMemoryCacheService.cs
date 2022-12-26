namespace Application.Main.Servicios.Generico.Interfaces
{
    public interface IMemoryCacheService
    {
        void SaveDataCache<T>(T data, string key);
        void RemoveDataCache(string key);
        object GetDataCache(string key);
    }
}
