using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Services;
using JourneyCreator.Api.Services;
using JourneyCreator.Infrastructure.Repositories;

namespace JourneyCreator.Api
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

            // services.AddSwaggerGen(c => {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Journey Creator API", Version = "v1" });
            // });


            // DI
            services.AddScoped<ICreationService, CreationService>();
            services.AddScoped<IRetrievalService, RetrievalService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IJourneyRepository, JourneyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseSwagger();

            // app.UseSwaggerUI(c => {
            //     c.SwaggerEndPoint("/swagger/v1/swagger.json", "Journey Creator API v1");
            // });

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
