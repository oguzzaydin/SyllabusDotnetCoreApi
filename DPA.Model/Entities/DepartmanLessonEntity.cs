namespace DPA.Model.Entities
{
    public class DepartmanLessonEntity: BaseEntity
    {
        public long LessonId { get; set; }

        public long DepartmanId { get; set; }

        public virtual DepartmanEntity Departman { get; set; }

        public virtual LessonEntity Lesson { get; set; }
    }
}