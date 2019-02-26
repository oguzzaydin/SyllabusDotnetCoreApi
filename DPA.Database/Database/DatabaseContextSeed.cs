using DotNetCore.Security;
using DPA.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DPA.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 1,
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                Login = new Hash().Create("admin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active,
                Title = Title.Administrator
            });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 2,
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@admin.com",
                Login = new Hash().Create("baskan"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active,
                Title = Title.Administrator
            });

            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 1,
                Title = "Kısıt 1",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                WeeklyHour = WeeklyHour.FifteenHour | WeeklyHour.TenHour,
                EducationType = EducationType.IIOgretim | EducationType.IOgretim,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 2
            });

            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 2,
                Title = "Kısıt 2",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = WeeklyHour.FifteenHour | WeeklyHour.TenHour,
                EducationType = EducationType.IIOgretim | EducationType.IOgretim,
                UserId = 2
            });

            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 1,
                Name = "Veritabanı",
                LessonCode = "BM211",
                Group = "A",
                AKTS = AKTS.Five,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Secmeli,
                EducationType = EducationType.IIOgretim,
                WeeklyHour = WeeklyHour.TenHour
            });

            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 2,
                Name = "Web Programlama",
                LessonCode = "BM211",
                Group = "A",
                AKTS = AKTS.Five,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Secmeli,
                EducationType = EducationType.IIOgretim,
                WeeklyHour = WeeklyHour.TenHour
            });

            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 3,
                Name = "Mat II",
                LessonCode = "BM211",
                Group = "A",
                AKTS = AKTS.Five,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Secmeli,
                EducationType = EducationType.IIOgretim,
                WeeklyHour = WeeklyHour.TenHour
            });

            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 4,
                Name = "Mat I",
                LessonCode = "BM211",
                Group = "B",
                AKTS = AKTS.Nine,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                EducationType = EducationType.Tumu,
                WeeklyHour = WeeklyHour.FiveHour
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 1,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 2
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 2,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 1
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 3,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 3
            });

            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 1,
                Title = "İlahiyat Fakültesi",
                FacultyCode = "IL10",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 2,
                Title = "Elektronik Fakültesi",
                FacultyCode = "IL10",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 3,
                Title = "Güzel Sanatlar Fakültesi",
                FacultyCode = "IL10",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 4,
                Title = "Bilgisayar Mühendisliği Fakültesi",
                FacultyCode = "BM310",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<DepartmanEntity>().HasData(new DepartmanEntity
            {
                DepartmanId = 1,
                Title = "Bilgisayar Muh. Bolumu",
                DepartmanCode = "BM310",
                FacultyId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<DepartmanEntity>().HasData(new DepartmanEntity
            {
                DepartmanId = 2,
                Title = "İlahiyat. Bolumu",
                DepartmanCode = "BM310",
                FacultyId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<DepartmanEntity>().HasData(new DepartmanEntity
            {
                DepartmanId = 3,
                Title = "İlahiyat. Bolumu",
                DepartmanCode = "BM310",
                FacultyId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 1,
                LessonId = 1,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 2,
                LessonId = 2,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 3,
                LessonId = 3,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 4,
                LessonId = 4,
                DepartmanId = 1
            });
        }
    }
}