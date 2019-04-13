using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public sealed class DepartmentLessonsEntityConfiguration : IEntityTypeConfiguration<DepartmentLessonEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DepartmentLessonEntity> builder)
        {
            builder.ToTable("DepartmentLesson", "Faculty");

            builder.HasKey(x => x.DepartmentLessonId);

            builder.Property(x => x.DepartmentLessonId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentLessons).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.DepartmentLessons).HasForeignKey(x => x.LessonId);
        }
    }
}