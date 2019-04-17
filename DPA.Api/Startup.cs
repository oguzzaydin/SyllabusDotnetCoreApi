using AutoMapper;
using DotNetCore.AspNetCore;
using DPA.Core;
using DPA.Core.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            application.UseSwaggerDefault("api");
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
            services.AddSwaggerDefault("api");
            services.AddSwaggerGenExtension();
            services.AddSwaggerDocExtensions();
            services.AddMvc()
            .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
    }
}