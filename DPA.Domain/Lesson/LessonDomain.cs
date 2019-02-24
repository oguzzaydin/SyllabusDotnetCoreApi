using System;
using DPA.Model;

namespace DPA.Domain
{
    public class LessonDomain
    {
        protected internal LessonDomain(
            string name,
            string lessonCode,
            string group,
            AKTS akts,
            LessonType lessonType,
            EducationType educationType,
            WeeklyHour weeklyHour
        ) {
            Name = name;
            LessonCode = lessonCode;
            Group = group;
            AKTS = akts;
            LessonType = lessonType;
            EducationType = educationType;
            WeeklyHour = weeklyHour;
        }
        

        public string Name { get; private set; }

        public string LessonCode { get; private set; }

        public string Group { get; private set; }
        
        public AKTS AKTS { get; private set; }

        public LessonType LessonType { get; private set; }

        public EducationType EducationType { get; private set; }
        
        public WeeklyHour WeeklyHour { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Add() {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateLessonModel updateLessonModel) {
            Name = updateLessonModel.Name;
            LessonCode = updateLessonModel.LessonCode;
            Group = updateLessonModel.Group;
            AKTS = updateLessonModel.AKTS;
            WeeklyHour = updateLessonModel.WeeklyHour;
            LessonType = updateLessonModel.LessonType;
            EducationType = updateLessonModel.EducationType;
            UpdatedDate = DateTime.Now;
        }

    }
}