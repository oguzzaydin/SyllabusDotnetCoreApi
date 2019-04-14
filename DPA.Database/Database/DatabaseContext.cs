using DotNetCore.EntityFrameworkCore;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();

            new DatabaseContextSeed().Seed(modelBuilder);
        }
    }
}