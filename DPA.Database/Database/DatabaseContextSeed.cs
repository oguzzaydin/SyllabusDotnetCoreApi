using DotNetCore.Security;
using DPA.Model.Entities;
using DPA.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                UserName = new Hash().Create("admin"),
                Password = new Hash().Create("123456"),
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active,
                Title = Title.Administrator
            });
        }
    }
}