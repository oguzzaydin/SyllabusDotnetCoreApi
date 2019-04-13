namespace DPA.Model
{
    public class DepartmentLessonEntity : BaseEntity
    {
        public long DepartmentLessonId { get; set; }

        public long LessonId { get; set; }

        public long DepartmentId { get; set; }

        public virtual DepartmentEntity Department { get; set; }

        public virtual LessonEntity Lesson { get; set; }
    }
}