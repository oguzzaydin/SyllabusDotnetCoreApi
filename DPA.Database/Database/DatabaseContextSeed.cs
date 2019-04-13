using DotNetCore.Security;
using DPA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DPA.Database
{
    public sealed class DatabaseContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {

            #region KULLANICILAR

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
                Roles = Roles.Administrator,
                Status = Status.Active,
                Title = Title.Administrator
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 2,
                Name = "Celal",
                Surname = "Çeken",
                Email = "celalceken@sakarya.edu.tr",
                Login = new Hash().Create("celal"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Profesor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 3,
                Name = "Cemil",
                Surname = "Öz",
                Email = "coz@sakarya.edu.tr",
                Login = new Hash().Create("cemil"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.Admin,
                Status = Status.Active,
                Title = Title.Profesor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 4,
                Name = "Ümit",
                Surname = "Kocabıçak",
                Email = "umit@sakarya.edu.tr",
                Login = new Hash().Create("umit"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Profesor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 5,
                Name = "Ahmet",
                Surname = "Zengin",
                Email = "azengin@sakarya.edu.tr",
                Login = new Hash().Create("ahmetzengin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.YardimciDocent
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 6,
                Name = "Ahmet",
                Surname = "Özmen",
                Email = "ozmen@sakarya.edu.tr",
                Login = new Hash().Create("umitozmen"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.YardimciDocent
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 7,
                Name = "Cüneyt",
                Surname = "Bayılmış",
                Email = "cbayilmis@sakarya.edu.tr",
                Login = new Hash().Create("cuneyt"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.YardimciDocent
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 8,
                Name = "Ahmet",
                Surname = "Arslan",
                Email = "ahmetarslan@sakarya.edu.tr",
                Login = new Hash().Create("ahmetarslan"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 9,
                Name = "Beyza",
                Surname = "Eken",
                Email = "beken@sakarya.edu.tr",
                Login = new Hash().Create("beyza"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 10,
                Name = "Deniz",
                Surname = "Balta",
                Email = "ddural@sakarya.edu.tr",
                Login = new Hash().Create("deniz"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 11,
                Name = "Oguzhan",
                Surname = "Aydın",
                Email = "oguz@sakarya.edu.tr",
                Login = new Hash().Create("oguzaydin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.OgretimGorevlisi
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 12,
                Name = "Hasan",
                Surname = "Tutan",
                Email = "hasantutan@sakarya.edu.tr",
                Login = new Hash().Create("hasantutan"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.OgretimGorevlisi
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 13,
                Name = "Ercan",
                Surname = "Palabıyık",
                Email = "ercanpala@sakarya.edu.tr",
                Login = new Hash().Create("palabiyik"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.OgretimGorevlisi
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 14,
                Name = "Meltem",
                Surname = "Aydın",
                Email = "meltemayy@sakarya.edu.tr",
                Login = new Hash().Create("meltemaydin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.OgretimGorevlisi
            });

            #endregion

            #region KULLANICI KISITLARI

            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 1,
                Title = "Kısıt 1",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                WeeklyHour = 4,
                EducationType = EducationType.IOgretim,
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
                WeeklyHour = 6,
                EducationType = EducationType.IIOgretim,
                UserId = 3
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 3,
                Title = "Kısıt 3",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 8,
                EducationType = EducationType.Tumu,
                UserId = 4
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 4,
                Title = "Kısıt 4",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 10,
                EducationType = EducationType.IIOgretim,
                UserId = 5
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 5,
                Title = "Kısıt 5",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 12,
                EducationType = EducationType.IOgretim,
                UserId = 6
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 6,
                Title = "Kısıt 6",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 14,
                EducationType = EducationType.Tumu,
                UserId = 7
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 7,
                Title = "Kısıt 7",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 8,
                EducationType = EducationType.IIOgretim,
                UserId = 8
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 8,
                Title = "Kısıt 8",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 10,
                EducationType = EducationType.IOgretim,
                UserId = 9
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 9,
                Title = "Kısıt 9",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 12,
                EducationType = EducationType.Tumu,
                UserId = 10
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 10,
                Title = "Kısıt 10",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 12,
                EducationType = EducationType.IOgretim,
                UserId = 11
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 11,
                Title = "Kısıt 11",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 12,
                EducationType = EducationType.IIOgretim,
                UserId = 12
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 12,
                Title = "Kısıt 12",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                EducationType = EducationType.Tumu,
                UserId = 13
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 13,
                Title = "Kısıt 13",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                EducationType = EducationType.Tumu,
                UserId = 14
            });

            #endregion

            #region DERSLER

            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 1,
                Name = "TÜRK DİLİ",
                LessonCode = "TUR 101",
                AKTS = 4,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 2,
                Name = "FİZİK I",
                LessonCode = "FIZ 111",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 5
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 3,
                Name = "MATEMATİK I",
                LessonCode = "MAT 111",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 4,
                Name = "LİNEER CEBİR",
                LessonCode = "MAT 113",
                AKTS = 4,
                Credit = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 2
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 5,
                Name = "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ",
                LessonCode = "BSM 101",
                AKTS = 4,
                Credit = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 2
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 6,
                Name = "PROGRAMLAMAYA GİRİŞ",
                LessonCode = "BSM 103",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.One,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 7,
                Name = "İNGİLİZCE",
                LessonCode = "ING 190",
                AKTS = 4,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 8,
                Name = "FİZİK II",
                LessonCode = "FIZ 112",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 5
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 9,
                Name = "MATEMATİK II",
                LessonCode = "MAT 112",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 10,
                Name = "NESNEYE DAYALI PROGRAMLAMA",
                LessonCode = "BSM 102",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 11,
                Name = "WEB TEKNOLOJİLERİ",
                LessonCode = "BSM 104",
                AKTS = 4,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 12,
                Name = "OLASILIK VE İSTATİSTİK",
                LessonCode = "IST 108",
                AKTS = 4,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Two,
                WeeklyHour = 3
            });

            #endregion

            #region DERS GRUPLARI

            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 1,
                LessonId = 1,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 2,
                LessonId = 1,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 3,
                LessonId = 2,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 4,
                LessonId = 2,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 5,
                LessonId = 3,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 6,
                LessonId = 3,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 7,
                LessonId = 4,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 8,
                LessonId = 5,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 9,
                LessonId = 6,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 10,
                LessonId = 6,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });

            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 11,
                LessonId = 7,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 12,
                LessonId = 7,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 13,
                LessonId = 8,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 14,
                LessonId = 8,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 15,
                LessonId = 9,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 16,
                LessonId = 9,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 17,
                LessonId = 10,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 18,
                LessonId = 10,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 19,
                LessonId = 11,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 20,
                LessonId = 11,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 21,
                LessonId = 12,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 22,
                LessonId = 12,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });

            #endregion

            #region HOCANIN DERSLERİ

            //----- 1. YARIYIL -----
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 1,
                UserId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 1
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 2,
                UserId = 8,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 1
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 3,
                UserId = 11,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 1
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 4,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 2
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 5,
                UserId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 2
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 6,
                UserId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 2
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 7,
                UserId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 3
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 8,
                UserId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 3
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 9,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 3
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 10,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 4
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 11,
                UserId = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 5
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 12,
                UserId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 6
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 13,
                UserId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 6
            });

            //----- 2. YARIYIL -----
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 14,
                UserId = 11,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 7
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 15,
                UserId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 7
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 16,
                UserId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 7
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 17,
                UserId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 8
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 18,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 8
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 19,
                UserId = 8,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 9
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 20,
                UserId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 9
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 21,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 9
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 22,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 10
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 23,
                UserId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 10
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 24,
                UserId = 6,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 11
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 25,
                UserId = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 11
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 26,
                UserId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 12
            });

            #endregion

            #region FAKÜLTELER

            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 1,
                Title = "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ",
                FacultyCode = "BM310",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 2,
                Title = "Mühendislik Fakültesi",
                FacultyCode = "MF123",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 3,
                Title = "Hukuk Fakültesi",
                FacultyCode = "HKK112",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            modelBuilder.Entity<FacultyEntity>().HasData(new FacultyEntity
            {
                FacultyId = 4,
                Title = "Teknoloji Fakültesi",
                FacultyCode = "TKL423",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            #endregion

            #region BÖLÜMLER

            modelBuilder.Entity<DepartmentEntity>().HasData(new DepartmentEntity
            {
                DepartmentId = 1,
                Title = "Bilgisayar Mühendisliği Bölümü",
                DepartmentCode = "BM310",
                FacultyId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                HeadOfDepartmentId = 1
            });

            modelBuilder.Entity<DepartmentEntity>().HasData(new DepartmentEntity
            {
                DepartmentId = 2,
                Title = "Bilişim Sistemleri Mühendisliği Bölümü",
                DepartmentCode = "BM311",
                FacultyId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<DepartmentEntity>().HasData(new DepartmentEntity
            {
                DepartmentId = 3,
                Title = "Yazılım Mühendisliği Bölümü",
                DepartmentCode = "BM312",
                FacultyId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            #endregion

            #region FAKÜLTE BÖLÜM İLİŞKİLERİ

            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 1,
                LessonId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 2,
                LessonId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 3,
                LessonId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 4,
                LessonId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 5,
                LessonId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 6,
                LessonId = 6,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 7,
                LessonId = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 8,
                LessonId = 8,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 9,
                LessonId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 10,
                LessonId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 11,
                LessonId = 11,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 12,
                LessonId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });

            #endregion

            #region DERSLİKLER

            for (int i = 0; i < 18; i++)
            {
                modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
                {
                    LocationId = i + 1,
                    Title = "100" + i,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    FacultyId = 1
                });
            }

            #endregion

        }
    }
}