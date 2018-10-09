using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampApp.Core.ApplicationService;
using LampApp.Core.ApplicationService.Services;
using LampApp.Core.DomainService;
using LampApp.Infrastructure.Data;
using LampApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class Startup
    {
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        public IConfiguration Configuration { get; }
        
        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                   
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddDbContext<LampAppContext>(
                    opt => opt.UseSqlServer("Data Source= lampApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<LampAppContext>(
                    opt => opt
                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<ILampRepository, LampRepositories>();
            services.AddScoped<ILampService, LampService>();
            services.AddScoped<IOrderRepository, OrderRepositories>();
            services.AddScoped<IOrderService, OrderService>();
            
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ltx = scope.ServiceProvider.GetService<LampAppContext>();
                    DBInitializer.SeedDB(ltx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ltx = scope.ServiceProvider.GetService<LampAppContext>();
                    ltx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}