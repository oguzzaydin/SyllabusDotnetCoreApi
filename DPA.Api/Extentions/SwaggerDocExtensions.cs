using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DPA.Api
{
    public static class SwaggerDocExtensions
    {
        public static void AddSwaggerDocExtensions(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = "Comments" + ".XML";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    c.IncludeXmlComments(commentsFile);
                });
        }
    }
}