using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class TimeEntityConfiguration : IEntityTypeConfiguration<TimeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Time", "Syllabus");

            builder.HasKey(x => x.TimeId);

            builder.Property(x => x.TimeId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.DayOfTheWeek).IsRequired();
            builder.Property(x => x.StarTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.UnitLesson).WithMany(x => x.TimeEntities).HasForeignKey(x => x.UnitLessonId);
        }
    }
}