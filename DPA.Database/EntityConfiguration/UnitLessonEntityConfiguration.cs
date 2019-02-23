using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public class UnitLessonEntityConfiguration : IEntityTypeConfiguration<UnitLessonEntity>
    {
        public void Configure(EntityTypeBuilder<UnitLessonEntity> builder)
        {
            builder.ToTable("UnitLessons", "Syllabus");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Lesson).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.User).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Location).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Syllabus).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);

            builder.HasMany(x => x.TimeEntities).WithOne(x => x.UnitLesson).HasForeignKey(x => x.UnitLessonId);

        }
    }
}