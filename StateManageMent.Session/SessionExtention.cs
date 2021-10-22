using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace StateManageMent.Session
{
    public static class SessionExtention
    {
        public static void Set<TInput>(this ISession session, string key, TInput input)
        {
            var serializedObject = JsonConvert.SerializeObject(input);
            session.SetString(key, serializedObject);
        }

        public static TOutput Get<TOutput>(this ISession session, string key)
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
