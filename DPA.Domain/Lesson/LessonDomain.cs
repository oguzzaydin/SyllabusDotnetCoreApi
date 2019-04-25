using DPA.Model;
using System;
using System.Collections.Generic;

namespace DPA.Domain
{
    public class LessonDomain
    {
        protected internal LessonDomain(
            string name,
            string lessonCode,
            int akts,
            LessonType lessonType,
            int weeklyHour
        )
        {
            Name = name;
            LessonCode = lessonCode;
            AKTS = akts;
            LessonType = lessonType;
            WeeklyHour = weeklyHour;
        }

        public string Name { get; private set; }
        public string LessonCode { get; private set; }
        public int AKTS { get; private set; }
        public LessonType LessonType { get; private set; }
        public int WeeklyHour { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public virtual List<LessonGroupEntity> LessonGroupEntities { get; private set; } = new List<LessonGroupEntity>();
        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void AddGroup(LessonGroupEntity lessonGroupEntity)
        {
           LessonGroupEntities.Add(lessonGroupEntity);
        }

        public void Update(UpdateLessonModel updateLessonModel)
        {
            Name = updateLessonModel.Name;
            LessonCode = updateLessonModel.LessonCode;
            AKTS = updateLessonModel.AKTS;
            WeeklyHour = updateLessonModel.WeeklyHour;
            LessonType = updateLessonModel.LessonType;
            UpdatedDate = DateTime.Now;
        }
    }
}