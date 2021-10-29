using HttpClientExample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly;
namespace HttpClientExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //services.AddHttpClient("jsonplaceholder", c =>
            //{
            //    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            //});
            services.AddTransient<ValidateApiKeyExists>();
            services.AddTransient<AddApiKey>();
            services.AddHttpClient();
            services.AddHttpClient<IJsonPlaceHolderProxy, JsonPlaceHolderProxy>()
                .AddTransientHttpErrorPolicy(policy =>

                    policy.WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromMilliseconds(2000),
                        TimeSpan.FromMilliseconds(4000),
                        TimeSpan.FromMilliseconds(500),
                    })
                )
                .AddHttpMessageHandler<AddApiKey>()
                .AddHttpMessageHandler<ValidateApiKeyExists>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HttpClientExample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HttpClientExample v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
