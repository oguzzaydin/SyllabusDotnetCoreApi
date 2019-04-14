using System;
using DPA.Model;

namespace DPA.Model
{
    public class TimeEntity : BaseEntity
    {
        public long TimeId { get; set; }

        public DayOfTheWeekType DayOfTheWeekType { get; set; }

        public int StarTime { get; set; }

        public int EndTime { get; set; }

        public long UnitLessonId { get; set; }

        public virtual UnitLessonEntity UnitLesson { get; set; }
    }
}