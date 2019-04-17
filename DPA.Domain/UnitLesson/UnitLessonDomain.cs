using System;
using System.Collections.Generic;
using DPA.Model;

namespace DPA.Domain.UnitLesson
{
    public class UnitLessonDomain
    {
        protected internal UnitLessonDomain
        (
            long lessonId,
            long userId,
            long locationId
        )
        {
            LessonId = lessonId;
            UserId = userId;
            LocationId = locationId;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public long UnitLessonId { get; private set; }
        public long LessonId { get; private set; }
        public long UserId { get; private set; }
        public long LocationId { get; private set; }
        public long SyllabusId { get; private set; }
        public char Group { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public virtual List<TimeEntity> TimeEntities { get; private set; } = new List<TimeEntity>();

        public void AddTime(DayOfTheWeekType dayOfTheWeekType,int startTime, int endTime)
        {
            TimeEntities.Add(new TimeEntity{
                DayOfTheWeekType = dayOfTheWeekType,
                StarTime = startTime,
                EndTime = endTime,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
        }

        public void AddGroup(UnitLessonEntity unit) 
        {
            Group = unit.Group;
        }

    }
}