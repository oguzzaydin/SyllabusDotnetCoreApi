using System.Collections.Generic;
using System.Linq;
using DotNetCore.AspNetCore;
using DPA.Core;
using DPA.Database.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DPA.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = environment.Configuration();
            Environment = environment;
        }

        private IConfiguration Configuration { get; }

        private IHostingEnvironment Environment { get; }

        public void Configure(IApplicationBuilder application)
        {
            application.UseExceptionDefault(Environment);
            application.UseCorsDefault();

            application.UseMiddleware<ErrorHandlingMiddleware>();

            application.UseHttpsRedirection();
            application.UseAuthentication();
            application.UseResponseCompression();
            application.UseResponseCaching();
            application.UseStaticFiles();
            application.UseMvcWithDefaultRoute();
            application.UseHealthChecks("/healthz");

          
            application.UseSwagger();
            application.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DPA API V1");
            });

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection(Configuration);
            services.AddCors();
            services.AddAuthenticationDefault();
            services.AddResponseCompression();
            services.AddResponseCaching();
            //services.AddAutoMapper();
            //services.AddMvcDefault();
            services.AddHealthChecks();
            // services.AddSwaggerDefault("api");
            services.AddSwaggerGen(c =>
             {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "Ders Programı Atama",
                        Description = "DPA Api"
                    });
                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        In = "Header",
                        Description = "JWT Authorization header using the Bearer scheme.Example: \"Bearer {token}\"",
                        Name = "Authorization"
                    });
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                                { "Bearer", Enumerable.Empty<string>() },
                    });
             });
            // services.AddSwaggerGenExtension();
            // services.AddSwaggerDocExtensions();
            services.AddMvc()
            .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
    }
}