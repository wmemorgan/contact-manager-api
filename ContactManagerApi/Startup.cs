using ContactManagerApi.Data;
using ContactManagerApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace ContactManagerApi
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
            services.Configure<DbOptions>(Configuration.GetSection("DbOptions"));
            services.AddSingleton<IDbContext, DbContext>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1", 
                    Title = "Contact Manager API",
                    Description = "REST API which manages contact records",
                    Contact = new OpenApiContact {
                        Name = "Wilfred Morgan",
                        Email = "wilfred@wilfredmorgan.com",
                        Url = new Uri("https://wilfredmorgan.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT license",
                        Url = new Uri("https://github.com/wmemorgan/contact-manager-api/blob/main/LICENSE"),
                    }        
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactManagerApi v1");
                c.RoutePrefix = string.Empty; // Set Swagger UI at apps root
            });

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
