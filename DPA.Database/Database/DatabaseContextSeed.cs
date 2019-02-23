using System;
using DotNetCore.Security;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
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
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active,
                Title = Title.Administrator
            });
        }
    }
}