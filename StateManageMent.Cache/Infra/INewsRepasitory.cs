using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageMent.Cache.Infra
{
    public interface INewsRepasitory
    {
        int GetNewsCount();
    }
    public class NewsRepasitory : INewsRepasitory
    {
        public int GetNewsCount()
        {
            System.Threading.Thread.Sleep(4000);
            return 20;
        }
    }
}
