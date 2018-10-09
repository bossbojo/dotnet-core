using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using AppApi.Configs;
using AppApi.Services;
using AppApi.Dependencies;

namespace AppApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();

            StaticVariables.ConnectionString = Configuration.GetConnectionString("ConnectionDB");
            
            StaticVariables.ProjectName = "SignalR Microservice";

            StaticVariables.Version = "0.1";
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            DependencyInjection.DependencyInjectionServices(services);
            CORS.CORSServices(services);
            Swagger.StartUpSwaggerConfigureServices(services);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) //Is Development mode
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction()) //Is Production mode
            {
                app.UseHsts();
            }
            else if (env.IsStaging()) //Is Staging mode
            {
                app.UseHsts();
            }

            Swagger.StartUpSwaggerConfigure(app);
            DefaultFiles.DefaultFilesConfigure(app);
            SignalRMapHub.SignalRMapHubConfigure(app);

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseRewriter();

        }
    }
}
