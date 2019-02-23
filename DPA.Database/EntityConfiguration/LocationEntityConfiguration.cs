using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationEntity> builder)
        {
            builder.ToTable("Locations", "Faculty");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Faculty).WithMany(x => x.Locations).HasForeignKey(x => x.FacultyId);
            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
        }
    }
}