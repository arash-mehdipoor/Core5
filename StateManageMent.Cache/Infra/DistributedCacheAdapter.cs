using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace StateManageMent.Cache.Infra
{
    public class DistributedCacheAdapter : ICacheAdapter
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheAdapter(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public TOutput Get<TOutput>(string key)
        {
            var serializedObject = _distributedCache.GetString(key);
            var result = default(TOutput);
            if (!string.IsNullOrEmpty(serializedObject))
            {
                result = JsonConvert.DeserializeObject<TOutput>(serializedObject);
            }
            return result;
        }

        public void Set<TInput>(string key, TInput input)
        {
            var serializedObject = JsonConvert.SerializeObject(input);
            _distributedCache.SetString(key, serializedObject);
        }
    }
}
