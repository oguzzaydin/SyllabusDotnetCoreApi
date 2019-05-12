using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DPA.Database.Database
{
    public sealed class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=tcp:dpadbserver.database.windows.net,1433;Initial Catalog=DPAApi-db;Persist Security Info=False;User ID=oguzzaydin@dpadbserver;Password=Oguz00315641;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var builder = new DbContextOptionsBuilder<DatabaseContext>();

            builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly.GetName().Name));

            return new DatabaseContext(builder.Options);
        }
    }
}