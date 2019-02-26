using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class UnitLessonEntityConfiguration : IEntityTypeConfiguration<UnitLessonEntity>
    {
        public void Configure(EntityTypeBuilder<UnitLessonEntity> builder)
        {
            builder.ToTable("UnitLessons", "Syllabus");

            builder.HasKey(x => x.UnitLessonId);
            builder.Property(x => x.UnitLessonId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Lesson).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.User).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Location).WithMany(x => x.UnitLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Syllabus).WithMany(x => x.UnitLessons)
            .HasForeignKey(x => x.LessonId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TimeEntities).WithOne(x => x.UnitLesson).HasForeignKey(x => x.UnitLessonId);
        }
    }
}