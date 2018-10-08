using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Newtonsoft.Json.Serialization;
using Webshop.Core;
using Webshop.Core.ApplicationService.implementation;
using Webshop.Core.DomainService;
using Webshop.Infrastructure.Data;

namespace ZAYAWebShopBackend
{
    public class Startup
    {
        IHostingEnvironment _env { get; set; }
        public IConfiguration _conf { get; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }


       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            if (_env.IsDevelopment())
            {
                  services.AddDbContext<WebShopAppContext>(
                    option => option.UseSqlite("Data Source=WebShopApp.db"));     
            }
            else if(_env.IsProduction())
            {
                services.AddDbContext<WebShopAppContext>(
                    option => option.UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
                
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // services.AddDbContext<>()
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            //Used to stop never ending loops
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<WebShopAppContext>();
                    
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
