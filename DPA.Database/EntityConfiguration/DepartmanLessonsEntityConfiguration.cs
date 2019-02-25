using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public sealed class DepartmanLessonsEntityConfiguration : IEntityTypeConfiguration<DepartmanLessonEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DepartmanLessonEntity> builder)
        {
            builder.ToTable("DepartmanLessons", "Faculty");

            builder.HasKey(x => x.DepartmanLessonId);

            builder.Property(x => x.DepartmanLessonId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Departman).WithMany(x => x.DepartmanLessons).HasForeignKey(x => x.DepartmanId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.DepartmanLessons).HasForeignKey(x => x.LessonId);


        }
    }
}