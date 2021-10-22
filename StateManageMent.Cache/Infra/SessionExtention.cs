using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace StateManageMent.Cache.Infra
{
    public static class SessionExtensions
    {
        public static void Set2<TInput>(this ISession session, string key, TInput input)
        {
            var serializedObject = JsonConvert.SerializeObject(input);
            session.SetString(key, serializedObject);
        }

        public static TOutput Get2<TOutput>(this ISession session, string key)
        {
            var result = session.GetString(key);
            var output = default(TOutput);
            if (string.IsNullOrEmpty(result))
            {
                output = JsonConvert.DeserializeObject<TOutput>(result);
            }
            return output;
        }

    }
}
