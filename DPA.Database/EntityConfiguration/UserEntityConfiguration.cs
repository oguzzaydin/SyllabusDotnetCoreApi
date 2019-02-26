using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Login).IsUnique();

            builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Roles).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasMany(x => x.UsersLogs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Constraints).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.UserLessons).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.UnitLessons).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Departman).WithOne(x => x.User).HasForeignKey<DepartmanEntity>(x => x.UserId);
        }
    }
}