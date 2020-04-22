using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lesson19_1.DataModels;
using Lesson19_1.Loger;
using Lesson19_1.Mappers;
using Lesson19_1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Lesson19_1
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyDbContext>(options => options.UseMySql(connectionString));

            services.AddMvc();

            services.AddAutoMapper(typeof(MappingEntity));

            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            
            //add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Brand project", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new DbLogerProvider(app));

            string swaggerName = null;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                swaggerName = "API IsDevelopment";
            }
            else if (env.IsProduction())
            {
                swaggerName = "API IsProduction";
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
                context.Database.Migrate();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerName);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
