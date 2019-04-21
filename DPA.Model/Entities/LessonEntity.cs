using System.Collections.Generic;
using DPA.Model;
using Newtonsoft.Json;

namespace DPA.Model
{
    public class LessonEntity : BaseEntity
    {
        public long LessonId { get; set; }
        public string Name { get; set; }
        public string LessonCode { get; set; }
        public int AKTS { get; set; }
        public int Credit { get; set; }
        public int WeeklyHour { get; set; }
        public SemesterType SemesterType { get; set; }
        public LessonType LessonType { get; set; }
        public virtual ICollection<UserLessonEntity> UserLessons { get; set; } = new HashSet<UserLessonEntity>();
        public virtual ICollection<DepartmentLessonEntity> DepartmentLessons { get; set; } = new HashSet<DepartmentLessonEntity>();
        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
        public virtual ICollection<LessonGroupEntity> LessonGroups { get; set; } = new HashSet<LessonGroupEntity>();
    }
}