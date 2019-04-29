using System.Collections.Generic;

namespace DPA.Model
{
    public class SyllabusEntity : BaseEntity
    {
        public long SyllabusId { get; set; }
        public int Year { get; set; }
        public PeriodType PeriodType { get; set; }
        public EducationType EducationType { get; set; }
        public int WeeklyHour { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}