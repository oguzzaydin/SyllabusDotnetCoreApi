using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class DepartmanEntityConfiguration : IEntityTypeConfiguration<DepartmanEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmanEntity> builder)
        {
            builder.ToTable("Departmans", "Faculty");

            builder.HasKey(x => x.DepartmanId);

            builder.Property(x => x.DepartmanId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DepartmanCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.Faculty).WithMany(x => x.Departmans).HasForeignKey(x => x.FacultyId);
            builder.HasMany(x => x.DepartmanLessons).WithOne(x => x.Departman).HasForeignKey(x => x.DepartmanId);
        }
    }
}