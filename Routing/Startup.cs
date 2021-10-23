using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Routing.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("vn", typeof(Nezamvazife));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                // WithMetadata
                endpoints.MapGet("/cp/{city}", async context =>
                {
                    await context.Response.WriteAsync("WithMetadata /cp/{city}");
                }).WithMetadata(new RouteNameMetadata("cityPop"));

                // fileName fileExtention
                endpoints.MapGet("/file/{fileName}.{fileExtention}", async context =>
                {
                    await context.Response.WriteAsync("file/{fileName}.{fileExtention} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // Proplem name => name
                endpoints.MapGet("/name{fname}", async context =>
                {
                    await context.Response.WriteAsync("/name{fname} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // Default Value
                endpoints.MapGet("/fName/{lName=Mehdipour}", async context =>
                {
                    await context.Response.WriteAsync("/fName/{lName=Mehdipour} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // Optional Parameters
                endpoints.MapGet("/first/{second?}", async context =>
                {
                    await context.Response.WriteAsync("/first/{second?} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // *catchall Parameters
                endpoints.MapGet("/first/{second}/{*catchall}", async context =>
                {
                    await context.Response.WriteAsync("/first/{second}/{*catchall}\n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // Constraint
                endpoints.MapGet("/{age:int}/{second:bool}", async context =>
                {
                    await context.Response.WriteAsync("/age:int/{second:bool} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                });

                // Custom Constraint || WithDisplayName
                endpoints.MapGet("/{vaziat:vn}", async context =>
                {
                    await context.Response.WriteAsync("/{vaziat:vn} \n");

                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}: {context.Request.RouteValues[item]} \n");
                    }
                }).WithDisplayName("Nezamvazife"); ;

                // Set Order
                endpoints.MapGet("/{int:int}", async context =>
                {
                    await context.Response.WriteAsync("Int");
                }).Add(d => ((RouteEndpointBuilder)d).Order = 2);
                endpoints.MapGet("/{d:double}", async context =>
                {
                    await context.Response.WriteAsync("double");
                }).Add(d => ((RouteEndpointBuilder)d).Order = 1);

                // Fallback
                endpoints.MapFallback(async context =>
                {
                    await context.Response.WriteAsync("Fallback working");
                });

            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Routing Not Working");
            });
        }
    }
}
