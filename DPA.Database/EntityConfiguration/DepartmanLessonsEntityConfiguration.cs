using DPA.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public class DepartmanLessonsEntityConfiguration : IEntityTypeConfiguration<DepartmanLessonEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DepartmanLessonEntity> builder)
        {
            builder.ToTable("DepartmanLessons", "Faculty");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Departman).WithMany(x => x.DepartmanLessons).HasForeignKey(x => x.DepartmanId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.DepartmanLessons).HasForeignKey(x => x.LessonId);


        }
    }
}