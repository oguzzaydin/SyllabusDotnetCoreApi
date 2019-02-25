namespace DPA.Model
{
    public abstract class UserLessonModel
    {
        public long UserLessonId { get; set; }

        public long UserId { get; set; }

        public long LessonId { get; set; }
    }
}