using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public sealed class LessonEntityConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LessonEntity> builder)
        {
            builder.ToTable("Lesson", "Faculty");

            builder.HasKey(x => x.LessonId);

            builder.Property(x => x.LessonId).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.WeeklyHour).IsRequired();
            builder.Property(x => x.LessonCode).IsRequired();
            builder.Property(x => x.AKTS).IsRequired();
            builder.Property(x => x.Credit).IsRequired();
            builder.Property(x => x.LessonType).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.UserLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            builder.HasMany(x => x.DepartmentLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
            builder.HasMany(x => x.LessonGroups).WithOne(x => x.Lesson).HasForeignKey(x => x.LessonId);
        }
    }
}