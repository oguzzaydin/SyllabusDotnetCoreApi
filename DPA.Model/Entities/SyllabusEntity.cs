using System.Collections.Generic;
using DPA.Model.Enums;

namespace DPA.Model.Entities
{
    public class SyllabusEntity: BaseEntity
    {
        public int Year { get; set; }

        public PeriodType PeriodType { get; set; }

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}