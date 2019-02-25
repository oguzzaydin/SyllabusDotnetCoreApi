using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class TimeEntityConfiguration : IEntityTypeConfiguration<TimeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Times", "Syllabus");

            builder.HasKey(x => x.TimeId);

            builder.Property(x => x.TimeId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.StarDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.UnitLesson).WithMany(x => x.TimeEntities).HasForeignKey(x => x.UnitLessonId);

        }
    }
}