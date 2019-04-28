using System.Collections.Generic;

namespace DPA.Model
{
    public class UnitLessonEntity : BaseEntity
    {
        public long UnitLessonId { get; set; }
        public long LessonId { get; set; }
        public long UserId { get; set; }
        public long LocationId { get; set; }
        public long SyllabusId { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public SemesterType SemesterType { get; set; }
        public LessonGroupType GroupType { get; set; }
        public DayOfTheWeekType DayOfTheWeekType { get; set; }
        public virtual LessonEntity Lesson { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual LocationEntity Location { get; set; }
        public virtual SyllabusEntity Syllabus { get; set; }
    }
}