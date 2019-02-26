namespace DPA.Model
{
    public class UserLessonEntity : BaseEntity
    {
        public long UserLessonId { get; set; }

        public long UserId { get; set; }

        public long LessonId { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual LessonEntity Lesson { get; set; }
    }
}