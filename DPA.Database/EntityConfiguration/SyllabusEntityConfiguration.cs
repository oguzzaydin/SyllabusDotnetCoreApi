using DPA.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public class SyllabusEntityConfiguration : IEntityTypeConfiguration<SyllabusEntity>
    {
        public void Configure(EntityTypeBuilder<SyllabusEntity> builder)
        {
            builder.ToTable("Syllabuses", "Syllabus");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.PeriodType).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Syllabus).HasForeignKey(x => x.SyllabusId);
        }
    }
}