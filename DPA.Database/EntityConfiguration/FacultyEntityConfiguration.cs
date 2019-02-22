using DPA.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FacultyEntity> builder)
        {
            builder.ToTable("Faculties", "Faculty");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FacultyCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.Locations).WithOne(x => x.Faculty).HasForeignKey(x => x.FacultyId);
            builder.HasMany(x => x.Departmans).WithOne(x => x.Faculty).HasForeignKey(x => x.FacultyId);


        }
    }
}