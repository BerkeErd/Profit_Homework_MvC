namespace Profit_Homework_MvC.CacheHelper
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);
        T Set<T>(string cacheKey, T value);

        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        void Remove(string cacheKey);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class;
        T GetOrAdd<T>(string key, Func<T> action) where T : class;
        Task Clear(string key);
        void ClearAll();
    }
}
