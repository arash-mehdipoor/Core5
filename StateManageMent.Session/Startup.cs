using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageMent.Session
{

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = "Server=.;Database=CacheDb;Integrated Security=true";
                options.SchemaName = "dbo";
                options.TableName = "tblCache";
                options.DefaultSlidingExpiration = TimeSpan.FromSeconds(20);
            });

            services.AddSession(c =>
            {
                c.IdleTimeout = TimeSpan.FromMinutes(30);
                c.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();

            app.Use(async (context, next) =>
            {

                context.Session.SetString("mySession", "Session 1");

                await context.Response.WriteAsync($"{context.Session.Id}");
                await next();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("");
                });
            });
        }
    }
}
