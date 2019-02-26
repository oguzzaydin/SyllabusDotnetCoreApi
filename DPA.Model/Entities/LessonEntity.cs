using System.Collections.Generic;

namespace DPA.Model
{
    public class LessonEntity : BaseEntity
    {
        public long LessonId { get; set; }

        public string Name { get; set; }

        public string LessonCode { get; set; }

        public string Group { get; set; }

        public AKTS AKTS { get; set; }

        public LessonType LessonType { get; set; }

        public EducationType EducationType { get; set; }

        public WeeklyHour WeeklyHour { get; set; }

        public virtual ICollection<UserLessonEntity> UserLessons { get; set; } = new HashSet<UserLessonEntity>();

        public virtual ICollection<DepartmanLessonEntity> DepartmanLessons { get; set; } = new HashSet<DepartmanLessonEntity>();

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}