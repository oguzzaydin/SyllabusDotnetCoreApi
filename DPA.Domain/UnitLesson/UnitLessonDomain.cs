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

        protected internal UnitLessonDomain
        (
            long unitLessonId,
            long locationId,
            int startTime,
            int endTime,
            DayOfTheWeekType DayOfTheWeekType
        )
        {
            UnitLessonId = unitLessonId;
            LocationId = locationId;
            StarTime = startTime;
            EndTime = endTime;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        protected internal UnitLessonDomain
        (
            long unitLessonId,
            long lessonId,
            long locationId,
            long syllabusId,
            long userId,
            int startTime,
            int endTime,
            SemesterType semesterType,
            LessonGroupType groupType,
            DayOfTheWeekType dayOfTheWeekType
        )
        {
            UnitLessonId = unitLessonId;
            LessonId = lessonId;
            LocationId = locationId;
            SyllabusId = syllabusId;
            UserId = userId;
            StarTime = startTime;
            EndTime = endTime;
            SemesterType = semesterType;
            GroupType = groupType;
            DayOfTheWeekType = dayOfTheWeekType;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public long UnitLessonId { get; private set; }
        public long LessonId { get; private set; }
        public long UserId { get; private set; }
        public long LocationId { get; private set; }
        public long SyllabusId { get; private set; }
        public LessonGroupType GroupType { get; private set; }
        public SemesterType SemesterType { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public DayOfTheWeekType DayOfTheWeekType { get; private set; }
        public int StarTime { get; private set; }
        public int EndTime { get; private set; }
        public void AddTime(DayOfTheWeekType dayOfTheWeekType, int startTime, int endTime)
        {
            DayOfTheWeekType = dayOfTheWeekType;
            StarTime = startTime;
            EndTime = endTime;
            UpdatedDate = DateTime.Now;
        }

        public void AddGroup(UnitLessonEntity unit)
        {
            GroupType = unit.GroupType;
        }

        public void Update(UpdateUnitLessonModel updateUnitLessonModel) {
            LocationId = updateUnitLessonModel.LocationId;
            StarTime = updateUnitLessonModel.StarTime;
            EndTime = updateUnitLessonModel.EndTime;
            DayOfTheWeekType = updateUnitLessonModel.DayOfTheWeekType;
        }
    }
}