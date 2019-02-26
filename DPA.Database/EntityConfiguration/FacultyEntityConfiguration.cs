using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public sealed class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FacultyEntity> builder)
        {
            builder.ToTable("Faculties", "Faculty");

            builder.HasKey(x => x.FacultyId);

            builder.Property(x => x.FacultyId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FacultyCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.Locations).WithOne(x => x.Faculty).HasForeignKey(x => x.FacultyId);
            builder.HasMany(x => x.Departmans).WithOne(x => x.Faculty).HasForeignKey(x => x.FacultyId);
        }
    }
}