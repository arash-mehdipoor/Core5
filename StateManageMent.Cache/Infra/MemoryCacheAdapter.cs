using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace StateManageMent.Cache.Infra
{
    public class MemoryCacheAdapter : ICacheAdapter
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheAdapter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TOutput Get<TOutput>(string key)
        {
            var result = _memoryCache.Get(key);
            TOutput output = default(TOutput);
            if (result != null)
            {
                output = JsonConvert.DeserializeObject<TOutput>(output.ToString());
            }
            return output;
        }

        public void Set<TInput>(string key, TInput input)
        {
            var serializedObject = JsonConvert.SerializeObject(input);
            _memoryCache.Set(key, serializedObject);
        }
    }
}
