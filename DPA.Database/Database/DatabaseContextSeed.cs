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
            //*************************** KULLANICILAR *********************/
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
                Title = Title.Profesör
            });


            // Bölüm başkanı
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
                Title = Title.Profesör
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
                Title = Title.Profesör
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
                Title = Title.Doçent
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
                Title = Title.Doçent
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
                Title = Title.Doçent
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
                Title = Title.AraştırmaGörevlisi
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
                Title = Title.AraştırmaGörevlisi
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
                Title = Title.AraştırmaGörevlisi
            });

            //*************************** KULLANICI KISITLARI *********************/
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

            //*************************** DERSLER *********************/
            modelBuilder.Entity<LessonEntity>().HasData(new LessonEntity
            {
                LessonId = 1,
                Name = "Programlamaya Giriş",
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
                UpdatedDate = DateTime.Now,
                UserId = 1

            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 1,
                LessonId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 2,
                LessonId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 3,
                LessonId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmanId = 1
            });

            modelBuilder.Entity<DepartmanLessonEntity>().HasData(new DepartmanLessonEntity
            {
                DepartmanLessonId = 4,
                LessonId = 4,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmanId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 1,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 2,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 3,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 4,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 5,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 6,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 7,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 8,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<LocationEntity>().HasData(new LocationEntity
            {
                LocationId = 9,
                Title = "1201",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                FacultyId = 1
            });

            modelBuilder.Entity<SyllabusEntity>().HasData(new SyllabusEntity
            {
                SyllabusId = 1,
                Year = 2018,
                PeriodType = PeriodType.Bahar,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                DepartmanId = 1,
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 1,
                LessonId = 1,
                UserId = 2,
                LocationId = 3,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 2,
                LessonId = 1,
                UserId = 2,
                LocationId = 1,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 3,
                LessonId = 1,
                UserId = 2,
                LocationId = 7,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 4,
                LessonId = 1,
                UserId = 2,
                LocationId = 3,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 5,
                LessonId = 1,
                UserId = 2,
                LocationId = 4,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 6,
                LessonId = 1,
                UserId = 2,
                LocationId = 5,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 7,
                LessonId = 1,
                UserId = 2,
                LocationId = 3,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 8,
                LessonId = 1,
                UserId = 2,
                LocationId = 6,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 9,
                LessonId = 1,
                UserId = 2,
                LocationId = 7,
                SyllabusId = 1
            });

            modelBuilder.Entity<UnitLessonEntity>().HasData(new UnitLessonEntity
            {
                UnitLessonId = 10,
                LessonId = 1,
                UserId = 2,
                LocationId = 8,
                SyllabusId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 1,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 2,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });


            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 3,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 4,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 5,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });


            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 6,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 7,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });


            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 8,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });

            modelBuilder.Entity<TimeEntity>().HasData(new TimeEntity
            {
                TimeId = 9,
                StarDate = DateTime.Now.ToLocalTime(),
                EndDate = DateTime.Now.ToLocalTime(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UnitLessonId = 1
            });
        }
    }
}