using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageMent.Cache.Infra
{
    public interface ICacheAdapter
    {
        TOutput Get<TOutput>(string key);
        void Set<TInput>(string key, TInput input);
    }
}
