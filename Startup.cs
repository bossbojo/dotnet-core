using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppApi.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AppApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => { builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().AllowAnyOrigin().WithOrigins(); }));

            services.AddSwaggerGen(c =>
            {
                // var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + "AppApi.XML";
                // c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", new Info { Title = "APP API", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var res = env.EnvironmentName;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseMvc(routes =>
                // {
                //     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                // });

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            }
            else if (env.IsProduction())
            {
                app.UseHsts();
            }
            else if (env.IsStaging())
            {
                app.UseHsts();
            }

            // Default App
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notification");
            });

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
