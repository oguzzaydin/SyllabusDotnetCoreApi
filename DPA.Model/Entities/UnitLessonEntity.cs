using System.Collections.Generic;

namespace DPA.Model
{
    public class UnitLessonEntity : BaseEntity
    {
        public long LessonId { get; set; }

        public long UserId { get; set; }

        public long LocationId { get; set; }

        public long SyllabusId { get; set; }

        public virtual LessonEntity Lesson { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual LocationEntity Location { get; set; }

        public virtual SyllabusEntity Syllabus { get; set; }


        public virtual ICollection<TimeEntity> TimeEntities { get; set; } = new HashSet<TimeEntity>();
    }
}