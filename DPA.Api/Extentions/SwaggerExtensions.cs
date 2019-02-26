using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace DPA.Api
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DPA API", Description = "Documentation" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "Header", Description = "Alana Token Giriniz.", Name = "Authorization" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
            });
        }
    }
}