using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class SyllabusEntityConfiguration : IEntityTypeConfiguration<SyllabusEntity>
    {
        public void Configure(EntityTypeBuilder<SyllabusEntity> builder)
        {
            builder.ToTable("Syllabus", "Syllabus");

            builder.HasKey(x => x.SyllabusId);
            builder.Property(x => x.SyllabusId).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.PeriodType).IsRequired();
            builder.Property(x => x.EducationType).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Syllabus).HasForeignKey(x => x.SyllabusId);
            builder.HasOne(x => x.Department).WithMany(x => x.Syllabus).HasForeignKey(x => x.DepartmentId);
        }
    }
}