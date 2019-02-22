using DPA.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public class LessonEntityConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LessonEntity> builder)
        {
            builder.ToTable("Lessons", "Faculty");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
    
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.WeeklyHour).IsRequired().HasMaxLength(5);
            builder.Property(x => x.LessonCode).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Group).IsRequired().HasMaxLength(5);
            builder.Property(x => x.AKTS).IsRequired();
            builder.Property(x => x.LessonType).IsRequired();
            builder.Property(x => x.EducationType).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.UserLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            builder.HasMany(x => x.DepartmanLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            
        }
    }
}