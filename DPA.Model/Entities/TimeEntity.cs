using System;
using System.Collections.Generic;

namespace DPA.Model
{
    public class TimeEntity : BaseEntity
    {
        public long TimeId { get; set; }

        public DateTime StarDate { get; set; }

        public DateTime EndDate { get; set; }

        public long UnitLessonId { get; set; }

        public virtual UnitLessonEntity UnitLesson { get; set; }
    }
}