using System;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public class LessonGroupEntityConfiguration : IEntityTypeConfiguration<LessonGroupEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LessonGroupEntity> builder)
        {
            builder.ToTable("LessonGroup", "Faculty");

            builder.HasKey(x => x.LessonGroupId);

            builder.Property(x => x.LessonGroupId).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.GroupType).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Lesson).WithMany(x => x.LessonGroups).HasForeignKey(x => x.LessonId);
        }
    }
}
