using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class ConstraintEntityConfiguration : IEntityTypeConfiguration<ConstraintEntity>
    {
        public void Configure(EntityTypeBuilder<ConstraintEntity> builder)
        {
            builder.ToTable("Constraint", "User");

            builder.HasKey(x => x.ConstraintId);

            builder.Property(x => x.ConstraintId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsFreeDay).IsRequired();
            builder.Property(x => x.WeeklyHour).IsRequired();
            builder.Property(x => x.EducationType).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

        }
    }
}