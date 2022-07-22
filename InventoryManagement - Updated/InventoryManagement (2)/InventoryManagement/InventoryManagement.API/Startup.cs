
using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Data.Contexts;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API
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
            services.AddCors();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllers();
            services.AddDbContext<InventoryManagementContext>(setup => setup.UseSqlServer(connectionString));
            services.AddDbContext<InventoryManagementContext>(setup => setup.UseInMemoryDatabase("demodb"));

            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Inventory Management API",
                    Description = "Allows wokring with inventory information in database",
                    TermsOfService = new Uri("http://www.cognizant.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "INTADM22DF33 POD1",
                        Email = "DF33Pod1@outlook.com",

                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                    In = ParameterLocation.Header,
                    Description = "Jwt token for authorized user"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {new OpenApiSecurityScheme(){Reference=new OpenApiReference{ Id="Bearer", Type=ReferenceType.SecurityScheme}}, new string[]{ } }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
                app.UseCors(options =>
                {
                    options.AllowAnyOrigin();   //accept request from all client
                    options.AllowAnyMethod();   //support all http operations like get, post, put, delete
                    options.AllowAnyHeader();   //support all http headers like content-type, accept, etc
                });
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Inventory Management API"));

                app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
