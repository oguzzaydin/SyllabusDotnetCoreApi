using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database.EntityConfiguration
{
    public sealed class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationEntity> builder)
        {
            builder.ToTable("Location", "Faculty");

            builder.HasKey(x => x.LocationId);
            builder.Property(x => x.LocationId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Faculty).WithMany(x => x.Locations).HasForeignKey(x => x.FacultyId);
            builder.HasMany(x => x.UnitLessons).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
        }
    }
}