using DPA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPA.Database.EntityConfiguration
{
    public class UserLessonEntityConfiguration : IEntityTypeConfiguration<UserLessonEntity>
    {
        public void Configure(EntityTypeBuilder<UserLessonEntity> builder)
        {
            builder.ToTable("UserLessons", "User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserLessons).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.UserLessons).HasForeignKey(x => x.LessonId);
        }
    }
}