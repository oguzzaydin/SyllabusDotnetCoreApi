using DotNetCore.IoC;
using DPA.Application;
using DPA.Database;
using DPA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace DPA.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHash();
            services.AddLogger(configuration);
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));

            services.AddDbContextEnsureCreatedMigrate<DatabaseContext>(options => options
                .UseSqlServer(configuration.GetConnectionString(nameof(DatabaseContext)))
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
            );

            services.AddClassesMatchingInterfacesFrom
            (
               typeof(IUserService).Assembly,
               typeof(IDatabaseUnitOfWork).Assembly,
               typeof(IUserDomainService).Assembly
            );

        }
    }
}
