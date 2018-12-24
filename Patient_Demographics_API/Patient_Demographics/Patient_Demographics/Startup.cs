using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Patient_Demographics_Domain.Interfaces;
using Patient_Demographics_Infrastructure;
using Patient_Demographics_Infrastructure.Repositories;
using Patient_Demographics_RestAPI.Filters;
using Patient_Demographics_Service.Interfaces;
using Patient_Demographics_Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Patient_Demographics
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                //WithOrigins("http://mysite.com") to safe access
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IPatientRepository, Patient_SQL_Repository>();
           // services.AddScoped<IPatientService, PatientService>();
            services.AddDbContext<PatientEFContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc(
                config => {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             app.UseCors("MyPolicy");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
