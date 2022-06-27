using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piekarnia.Api.BindingModels;
using Piekarnia.Api.Middlewares;
using Piekarnia.Api.Validation;
/*using Piekarnia.Api.HealthChecks;*/
using Piekarnia.Data.Sql;
using Piekarnia.Data.Sql.Migrations;
using Piekarnia.Data.Sql.Client;
using Piekarnia.IData.Client;
using Piekarnia.IServices.Client;
using Piekarnia.Services.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Piekarnia.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
/*        private const string MySqlHealthCheckName = "mysql";*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PiekarniaDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("PiekarniaDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditClient>, EditClientValidator>();
            services.AddTransient<IValidator<CreateClient>, CreateClientValidator>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
/*            services.AddHealthChecks()
                .AddMySql(
                    Configuration.GetConnectionString("PiekarniaDbServer"),
                    4,
                    10,
                    MySqlHealthCheckName);*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //wystawienie pod adresem /healthy stanu healthchecków
            //app.UseHealthChecks("/healthy");
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PiekarniaDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();

                //sprawdzenie czy health check się powiódł
/*                var healthCheck = serviceScope.ServiceProvider.GetRequiredService<HealthCheckService>();
                if (healthCheck.CheckHealthAsync().Result?.Entries[MySqlHealthCheckName].Status 
                    == HealthCheckResult.Healthy().Status)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    databaseSeed.Seed();
                }*/
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}