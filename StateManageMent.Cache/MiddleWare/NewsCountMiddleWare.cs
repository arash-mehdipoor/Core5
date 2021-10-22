using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StateManageMent.Cache.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageMent.Cache.MiddleWare
{
    public class NewsCountMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly INewsRepasitory _newsRepasitory;
        private readonly ICacheAdapter _cacheAdapter;
        private readonly IDistributedCache _distributedCache;
        //private readonly IMemoryCache _memoryCache;

        //public NewsCountMiddleWare(
        //    RequestDelegate next,
        //    INewsRepasitory newsRepasitory,
        //    IMemoryCache memoryCache)
        //{
        //    _next = next;
        //    _newsRepasitory = newsRepasitory;
        //    _memoryCache = memoryCache;
        //}

        //public NewsCountMiddleWare(
        //    RequestDelegate next,
        //    INewsRepasitory newsRepasitory,
        //    IDistributedCache distributedCache)
        //{
        //    _next = next;
        //    _newsRepasitory = newsRepasitory;
        //    _distributedCache = distributedCache;
        //}

        public NewsCountMiddleWare(
            RequestDelegate next,
            INewsRepasitory newsRepasitory,
            ICacheAdapter cacheAdapter)
        {
            _next = next;
            _newsRepasitory = newsRepasitory;
            _cacheAdapter = cacheAdapter;
        }

        public async Task Invoke(HttpContext context)
        {
            //var newsCount = _memoryCache.Get("newsCount");
            //if (newsCount == null)
            //{
            //    newsCount = _newsRepasitory.GetNewsCount();
            //    _memoryCache.Set("newsCount", newsCount);
            //}

            var newsCount = _cacheAdapter.Get<string>("newsCount");
            if (string.IsNullOrEmpty(newsCount))
            {
                newsCount = _newsRepasitory.GetNewsCount().ToString();
                _cacheAdapter.Set("newsCount", newsCount);
            }

            await context.Response.WriteAsync($"{newsCount} \n");
            await _next(context);
        }
    }
}
