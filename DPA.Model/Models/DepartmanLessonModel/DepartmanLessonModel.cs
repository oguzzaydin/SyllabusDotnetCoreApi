namespace DPA.Model
{
    public abstract class DepartmanLessonModel
    {
        public long DepartmanLessonId { get; set; }

        public long LessonId { get; set; }

        public long DepartmanId { get; set; }
    }
}