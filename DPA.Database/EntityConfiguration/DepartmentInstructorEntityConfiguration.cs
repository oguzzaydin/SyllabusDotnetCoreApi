using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class DepartmentInstructorEntityConfiguration : IEntityTypeConfiguration<DepartmentInstructorEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentInstructorEntity> builder)
        {
            builder.ToTable("DepartmentInstructor", "Department");

            builder.HasKey(x => x.DepartmentInstructorId);
            builder.Property(x => x.DepartmentInstructorId).IsRequired().ValueGeneratedOnAdd();


            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentInstructors).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.User).WithMany(x => x.DepartmentInstructors).HasForeignKey(x => x.UserId);
        }
    }
}