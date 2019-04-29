using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("Department", "Faculty");

            builder.HasKey(x => x.DepartmentId);

            builder.Property(x => x.DepartmentId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DepartmentCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstActiveSyllabusId);
            builder.Property(x => x.SecondActiveSyylabusId);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Faculty).WithMany(x => x.Departments).HasForeignKey(x => x.FacultyId);

            builder.HasMany(x => x.DepartmentInstructors).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
            builder.HasMany(x => x.DepartmentLessons).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
            builder.HasMany(x => x.Syllabus).WithOne(x => x.Department).HasForeignKey(x => x.SyllabusId);
            
        }
    }
}