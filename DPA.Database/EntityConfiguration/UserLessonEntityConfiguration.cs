using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public sealed class UserLessonEntityConfiguration : IEntityTypeConfiguration<UserLessonEntity>
    {
        public void Configure(EntityTypeBuilder<UserLessonEntity> builder)
        {
            builder.ToTable("UserLessons", "User");

            builder.HasKey(x => x.UserLessonId);

            builder.Property(x => x.UserLessonId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserLessons).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.UserLessons).HasForeignKey(x => x.LessonId);
        }
    }
}