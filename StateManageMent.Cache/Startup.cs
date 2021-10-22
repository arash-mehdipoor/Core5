using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StateManageMent.Cache.Infra;
using StateManageMent.Cache.MiddleWare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageMent.Cache
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();

            var distributedCache = true;
            if (distributedCache)
            {
                //services.AddDistributedMemoryCache();
                services.AddDistributedSqlServerCache(options =>
                {
                    options.ConnectionString = "Server=.;Database=CacheDb;Integrated Security=true";
                    options.SchemaName = "dbo";
                    options.TableName = "tblCache";
                    options.DefaultSlidingExpiration = TimeSpan.FromMinutes(60000);
                });
                services.AddSingleton<ICacheAdapter, DistributedCacheAdapter>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddSingleton<ICacheAdapter, MemoryCacheAdapter>();
            }
            //services.AddDistributedMemoryCache();
            services.AddTransient<INewsRepasitory, NewsRepasitory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<NewsCountMiddleWare>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
