using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.Mapping;
using DPA.Domain.UnitLesson;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.SyllabusModel.Dtos;
using DPA.Model.Models.UserModel.Dtos;

namespace DPA.Domain
{
    public class SyllabusDomain
    {
        protected internal SyllabusDomain(long departmentId, SemesterType semesterType, PeriodType periodType, EducationType educationType, int weeklyHour)
        {
            DepartmentId = departmentId;
            PeriodType = periodType;
            SemesterType = semesterType;
            EducationType = educationType;
            Year = (int)educationType == 1 ? DateTime.Now.Year : DateTime.Now.Year + 1;
            WeeklyHour = weeklyHour;
        }

        #region prop
        public long SyllabusId { get; private set; }
        public int Year { get; private set; }
        public SemesterType SemesterType { get; private set; }
        public PeriodType PeriodType { get; private set; }
        public EducationType EducationType { get; private set; }
        public int WeeklyHour { get; private set; }
        public long DepartmentId { get; private set; }
        public virtual DepartmentEntity Department { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime UpdatedDate { get; private set; } = DateTime.Now;

        public virtual List<UnitLessonEntity> UnitLessons { get; private set; } = new List<UnitLessonEntity>();
        #endregion

        #region  DERS ATAMA
        public void AddUnitLesson(UnitLessonEntity unitLessons)
        {
            UnitLessons.Add(unitLessons);
        }
        public void AssignToLesson(IList<SyllabusForLessonWithGroupListDto> lessons, CreateSyllabusRequest request)
        {
            lessons.Shuffle();
            var lesson = lessons.FirstOrDefault();

            while (lessons.Count != 0)
            {
                foreach (var group in lesson.LessonGroups)
                {
                    AssignLessonCheckCriteria(lesson, group.GroupType);
                }
                lessons.Remove(lesson);
                lesson = lessons.FirstOrDefault();
            }
        }
        private void AssignLessonCheckCriteria(SyllabusForLessonWithGroupListDto lesson, LessonGroupType groupType)
        {
            if (lesson.WeeklyHour > 2)
            {
                //3 saat ard arda ata
                if (lesson.WeeklyHour == 3)
                {
                    UnitAssignToLesson(lesson.LessonId, 3, groupType);
                }
                else
                {
                    //2 saat art arda ata
                    UnitAssignToLesson(lesson.LessonId, 2, groupType);
                    lesson.WeeklyHour = lesson.WeeklyHour - 2;

                    if (lesson.WeeklyHour != 0)
                    {
                        AssignLessonCheckCriteria(lesson, groupType);
                    }
                }
            }
            else
            {
                if (lesson.WeeklyHour == 1)
                    //1 tane boş birim bul ata
                    UnitAssignToLesson(lesson.LessonId, 1, groupType);
                else
                    // 2 tane aynı günde boş birim bul ard arda ata
                    UnitAssignToLesson(lesson.LessonId, 2, groupType);
            }
        }
        private void UnitAssignToLesson(long lessonId, int hour, LessonGroupType groupType)
        {
            var emptyUnits = UnitEmptySearch(hour);
            // index null gelirse yeni tablo oluşmuş demektir orda arama yapmak için
            if (emptyUnits.Count == 0)
            {
                emptyUnits = UnitEmptySearch(hour);
            }
            else
            {
                foreach (var item in emptyUnits)
                {
                    int index = UnitLessons.IndexOf(item);
                    if (index > 0 || index == 0)
                    {
                        UnitLessons[index].LessonId = lessonId;
                        UnitLessons[index].GroupType = groupType;
                    }
                }
            }
        }
        private List<UnitLessonEntity> UnitEmptySearch(int hour)
        {
            var days = new List<DayOfTheWeekType> { DayOfTheWeekType.One, DayOfTheWeekType.Two, DayOfTheWeekType.Three, DayOfTheWeekType.Four, DayOfTheWeekType.Five };
            var units = GetEmptyUnitsForDay(days);
            days.Remove(units.First().DayOfTheWeekType);
            var emptyUnit = new List<UnitLessonEntity>();

            //Bu kısımda dizide aranan sayıda boşluk var ise yerler değiştirilip uygun yer açılacak ard arda değil ise
            while (days.Count != 0)
            {
                if (units.Count == hour || units.Count > hour)
                {
                    emptyUnit = GetEmptyIndexForUnits(units, hour);
                    if (emptyUnit.Count == 0)
                    {
                        units = GetEmptyUnitsForDay(days);
                        days.Remove(units.First().DayOfTheWeekType);
                    }
                    else
                    {
                        days.Clear();
                        return emptyUnit;
                    }

                }
                else
                {
                    CreateSyllabusDefaultTable(EducationType);
                    return emptyUnit;
                }
            }
            return emptyUnit;
        }
        private List<UnitLessonEntity> GetEmptyIndexForUnits(List<UnitLessonEntity> units, int hour)
        {
            var empytUnit = new List<UnitLessonEntity>();

            if (hour == 3)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    if (units.Count >= 3 && units[i].EndTime == units[i + 1].StarTime && units[i + 1].EndTime == units[i + 2].StarTime)
                    {
                        empytUnit.Add(units[i]);
                        if (empytUnit.Count == hour)
                            return empytUnit;
                    }
                }
            }
            if (hour == 2)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    if (units.Count >= 2 && units[i].EndTime == units[i + 1].StarTime)
                    {
                        empytUnit.Add(units[i]);
                        if (empytUnit.Count == hour)
                            return empytUnit;
                    }
                }
            }
            if (hour == 1)
                empytUnit.Add(units.First());

            return empytUnit;
        }
        private List<UnitLessonEntity> GetEmptyUnitsForDay(List<DayOfTheWeekType> days)
        {
            days.Shuffle();
            var day = days.First();
            return UnitLessons.FindAll(x => x.LessonId == 0 && x.DayOfTheWeekType == day);
        }
        public void CreateSyllabusDefaultTable(EducationType educationType)
        {
            if ((int)educationType == 1)
                CreatorTimeTable(9, 15);
            else
                CreatorTimeTable(15, 23);

        }
        private void CreatorTimeTable(int startTime, int endTime)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = startTime; j <= endTime; j++)
                {
                    var unitLessonDomain = UnitLessonDomainFactory.Create();
                    unitLessonDomain.AddTime((DayOfTheWeekType)i, j, j + 1);
                    var unitEntity = unitLessonDomain.Map<UnitLessonEntity>();
                    AddUnitLesson(unitEntity);
                }
            }
        }
        #endregion

        #region ÖĞRETMEN ATAMA
        public void AssignToTeacher(List<SyllabusForLessonWithGroupListDto> teacherForLesson, SyllabusForUserWithConstraintListDto teacher)
        {
            var emptyUnit = UnitLessons.FindAll(x => x.UserId == 0 && teacherForLesson.Contains(teacherForLesson.Find(y => y.LessonId == x.LessonId)));

            // if (teacher.IsFreeDay)
            // {

            // } else {

            // }
        }
        #endregion
    }
}
