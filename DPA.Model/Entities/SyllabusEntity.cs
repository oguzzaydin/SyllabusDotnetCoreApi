using System.Collections.Generic;

namespace DPA.Model
{
    public class SyllabusEntity: BaseEntity
    {
        public int Year { get; set; }

        public PeriodType PeriodType { get; set; }

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}