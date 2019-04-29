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
            //ADMINISTRATOR
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
            //PROF
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
                Name = "Nejat",
                Surname = "Yumuşak",
                Email = "nejat@sakarya.edu.tr",
                Login = new Hash().Create("nejat"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Profesor
            });
            //DOC
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 6,
                Name = "Ahmet",
                Surname = "Zengin",
                Email = "ahmet@zengin.edu.tr",
                Login = new Hash().Create("ahmet@zengin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 7,
                Name = "Ahmet",
                Surname = "Özmen",
                Email = "ahmet@ozmen.edu.tr",
                Login = new Hash().Create("ahmet@ozmen"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 8,
                Name = "Cüneyt",
                Surname = "Bayılmış",
                Email = "cbayilmis@sakarya.edu.tr",
                Login = new Hash().Create("cbayilmis"),
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
                Name = "Devrim",
                Surname = "Akgün",
                Email = "dakgun@sakarya.edu.tr",
                Login = new Hash().Create("dakgun"),
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
                Name = "İbrahim",
                Surname = "Özçelik",
                Email = "ozcelik@sakarya.edu.tr",
                Login = new Hash().Create("ozcelik"),
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
                Name = "Nilüfer",
                Surname = "Yurtay",
                Email = "nyurtay@sakarya.edu.tr",
                Login = new Hash().Create("nyurtay"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.DocentDoktor
            });
            //DOKTOR
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 12,
                Name = "Abdullah",
                Surname = "Sevin",
                Email = "asevin@sakarya.edu.tr",
                Login = new Hash().Create("asevin"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 13,
                Name = "Ali",
                Surname = "Gülbağ",
                Email = "agulbag@sakarya.edu.tr",
                Login = new Hash().Create("agulbag"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 14,
                Name = "Fatih",
                Surname = "Adak",
                Email = "fatihadak@sakarya.edu.tr",
                Login = new Hash().Create("fatihadak"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 15,
                Name = "Murat",
                Surname = "İskefiyeli",
                Email = "miskef@sakarya.edu.tr",
                Login = new Hash().Create("miskef"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 16,
                Name = "Seçkin",
                Surname = "Arı",
                Email = "seckinari@sakarya.edu.tr",
                Login = new Hash().Create("seckinari"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 17,
                Name = "Serap",
                Surname = "Kazan",
                Email = "serapkazan@sakarya.edu.tr",
                Login = new Hash().Create("serapkazan"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 18,
                Name = "Can",
                Surname = "Yüzkollar",
                Email = "can@sakarya.edu.tr",
                Login = new Hash().Create("cancan"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
            });
            //Öğretim Görevlisi
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 19,
                Name = "Yüksel",
                Surname = "Yurtay",
                Email = "yyurtay@sakarya.edu.tr",
                Login = new Hash().Create("yyurtay"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.OgretimGorevlisi
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 20,
                Name = "Nevzat",
                Surname = "Taşbaşı",
                Email = "ntasbasi@sakarya.edu.tr",
                Login = new Hash().Create("ntasbasi"),
                Password = new Hash().Create("123456"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Roles = Roles.User,
                Status = Status.Active,
                Title = Title.Doktor
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
                StartTime = 10,
                EndTime = 15,
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
                StartTime = 15,
                EndTime = 20,
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
                StartTime = 9,
                EndTime = 20,
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
                StartTime = 18,
                EndTime = 23,
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
                StartTime = 13,
                EndTime = 15,
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
                StartTime = 9,
                EndTime = 18,
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
                StartTime = 17,
                EndTime = 22,
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
                StartTime = 11,
                EndTime = 15,
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
                StartTime = 11,
                EndTime = 18,
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
                StartTime = 11,
                EndTime = 18,
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
                StartTime = 16,
                EndTime = 20,
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
                StartTime = 12,
                EndTime = 20,
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
                StartTime = 12,
                EndTime = 22,
                EducationType = EducationType.Tumu,
                UserId = 14
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 14,
                Title = "Kısıt 14",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                StartTime = 18,
                EndTime = 22,
                EducationType = EducationType.IIOgretim,
                UserId = 15
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 15,
                Title = "Kısıt 15",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 12,
                StartTime = 10,
                EndTime = 15,
                EducationType = EducationType.IOgretim,
                UserId = 16
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 16,
                Title = "Kısıt 16",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                StartTime = 10,
                EndTime = 18,
                EducationType = EducationType.Tumu,
                UserId = 17
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 17,
                Title = "Kısıt 17",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 9,
                StartTime = 15,
                EndTime = 15,
                EducationType = EducationType.IOgretim,
                UserId = 18
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 18,
                Title = "Kısıt 18",
                Description = "Description",
                IsFreeDay = false,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                StartTime = 18,
                EndTime = 22,
                EducationType = EducationType.IIOgretim,
                UserId = 19
            });
            modelBuilder.Entity<ConstraintEntity>().HasData(new ConstraintEntity
            {
                ConstraintId = 19,
                Title = "Kısıt 19",
                Description = "Description",
                IsFreeDay = true,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeeklyHour = 16,
                StartTime = 13,
                EndTime = 15,
                EducationType = EducationType.IOgretim,
                UserId = 20
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
            //3. YARIYIL    
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 7,
                Name = "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ",
                LessonCode = "ATA 203",
                AKTS = 4,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 8,
                Name = "SAYISAL ANALİZ",
                LessonCode = "MAT 217",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 9,
                Name = "ELEKTRİK DEVRE TEMELLERİ",
                LessonCode = "BSM 201",
                AKTS = 2,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 2
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 10,
                Name = "MANTIK DEVRELERİ",
                LessonCode = "BSM 203",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 11,
                Name = "WEB PROGRAMLAMA",
                LessonCode = "BSM 205",
                AKTS = 6,
                Credit = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 4
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 12,
                Name = "VERİ YAPILARI",
                LessonCode = "BSM 207",
                AKTS = 6,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Three,
                WeeklyHour = 3
            });

            //5. YARIYIL
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 13,
                Name = "BİÇİMSEL DİLLER VE SOYUT MAKİNELER",
                LessonCode = "BSM 301",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Five,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 14,
                Name = "VERİTABANI YÖNETİM SİSTEMLERİ",
                LessonCode = "BSM 301",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Five,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 15,
                Name = "İŞARETLER VE SİSTEMLER",
                LessonCode = "BSM 301",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Five,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 16,
                Name = "İŞLETİM SİSTEMLERİ",
                LessonCode = "BSM 301",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Five,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 17,
                Name = "VERİ İLETİŞİMİ",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Five,
                WeeklyHour = 3
            });

            //7. YARIYIL
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 18,
                Name = "BF-TEKNİK SEÇMELİ 1",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 19,
                Name = "BF-TEKNİK SEÇMELİ 2",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 20,
                Name = "BF-TEKNİK SEÇMELİ 3",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 21,
                Name = "BF-TEKNİK SEÇMELİ 4",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 22,
                Name = "BF-TEKNİK SEÇMELİ 5",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 23,
                Name = "BF-TEKNİK SEÇMELİ 6",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
                WeeklyHour = 3
            });
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 24,
                Name = "BF-TEKNİK SEÇMELİ 7",
                LessonCode = "BSM 305",
                AKTS = 5,
                Credit = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonType = LessonType.Bolum_Zorunlu,
                SemesterType = SemesterType.Seven,
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
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 23,
                LessonId = 13,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 24,
                LessonId = 13,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 25,
                LessonId = 13,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 26,
                LessonId = 14,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 27,
                LessonId = 14,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 28,
                LessonId = 14,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 29,
                LessonId = 15,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 30,
                LessonId = 15,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 31,
                LessonId = 15,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 32,
                LessonId = 16,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 33,
                LessonId = 16,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 34,
                LessonId = 16,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 35,
                LessonId = 17,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 36,
                LessonId = 17,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 37,
                LessonId = 17,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 38,
                LessonId = 18,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 39,
                LessonId = 18,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 40,
                LessonId = 18,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 41,
                LessonId = 19,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 42,
                LessonId = 19,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 43,
                LessonId = 19,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });

            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 44,
                LessonId = 20,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 45,
                LessonId = 20,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 46,
                LessonId = 20,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });

            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 47,
                LessonId = 21,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 48,
                LessonId = 21,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 49,
                LessonId = 21,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 50,
                LessonId = 22,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 51,
                LessonId = 22,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 52,
                LessonId = 22,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 53,
                LessonId = 23,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 54,
                LessonId = 23,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 55,
                LessonId = 23,
                GroupType = LessonGroupType.C,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 56,
                LessonId = 24,
                GroupType = LessonGroupType.A,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 57,
                LessonId = 24,
                GroupType = LessonGroupType.B,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            });
            modelBuilder.Entity<LessonGroupEntity>().HasData(new LessonGroupEntity
            {
                LessonGroupId = 58,
                LessonId = 24,
                GroupType = LessonGroupType.C,
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

            //----- 3. YARIYIL -----
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
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 27,
                UserId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 12
            });
            //---------5.YARIYIL----------------------------
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 28,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 13
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 29,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 13
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 30,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 13
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 31,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 14
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 32,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 14
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 33,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 14
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 34,
                UserId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 15
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 35,
                UserId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 15
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 36,
                UserId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 15
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 37,
                UserId = 16,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 16
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 38,
                UserId = 16,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 16
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 39,
                UserId = 16,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 16
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 40,
                UserId = 17,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 17
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 41,
                UserId = 17,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 17
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 42,
                UserId = 17,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 17
            });

            //--------------7.YARIYIL----------------------------------------------

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 43,
                UserId = 18,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 18
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 44,
                UserId = 18,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 18
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 45,
                UserId = 18,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 18
            });


            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 46,
                UserId = 19,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 19
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 47,
                UserId = 19,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 19
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 48,
                UserId = 19,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 19
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 49,
                UserId = 20,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 20
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 50,
                UserId = 20,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 20
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 51,
                UserId = 20,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 20
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 52,
                UserId = 8,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 21
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 53,
                UserId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 21
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 54,
                UserId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 21
            });

            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 55,
                UserId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 22
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 56,
                UserId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 22
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 57,
                UserId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 22
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 58,
                UserId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 23
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 59,
                UserId = 11,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 23
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 60,
                UserId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 23
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 61,
                UserId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 24
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 62,
                UserId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 24
            });
            modelBuilder.Entity<UserLessonEntity>().HasData(new UserLessonEntity
            {
                UserLessonId = 63,
                UserId = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                LessonId = 24
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

            #region KULLANICI BÖLÜM İLİŞKİLERİ
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 1,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 2,
                UserId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 3,
                UserId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 4,
                UserId = 5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 5,
                UserId = 6,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 6,
                UserId = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 7,
                UserId = 8,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 8,
                UserId = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 9,
                UserId = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 10,
                UserId = 11,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 11,
                UserId = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 12,
                UserId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 13,
                UserId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 14,
                UserId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 15,
                UserId = 16,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 16,
                UserId = 17,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 17,
                UserId = 18,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 18,
                UserId = 19,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentInstructorEntity>().HasData(new DepartmentInstructorEntity
            {
                DepartmentInstructorId = 19,
                UserId = 20,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            #endregion
            
            #region DERS BÖLÜM İLİŞKİLERİ

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
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 13,
                LessonId = 13,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 14,
                LessonId = 14,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 15,
                LessonId = 15,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 16,
                LessonId = 16,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 17,
                LessonId = 17,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 18,
                LessonId = 18,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 19,
                LessonId = 19,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 20,
                LessonId = 20,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 21,
                LessonId = 21,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 22,
                LessonId = 22,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 23,
                LessonId = 23,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmentId = 1
            });
            modelBuilder.Entity<DepartmentLessonEntity>().HasData(new DepartmentLessonEntity
            {
                DepartmentLessonId = 24,
                LessonId = 24,
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