using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.Mapping;
using DPA.Domain.UnitLesson;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.LocationModel.Dtos;
using DPA.Model.Models.SyllabusModel.Dtos;
using DPA.Model.Models.UserModel.Dtos;

namespace DPA.Domain
{
    public class SyllabusDomain
    {
        protected internal SyllabusDomain(long departmentId, PeriodType periodType, EducationType educationType)
        {
            DepartmentId = departmentId;
            PeriodType = periodType;
            EducationType = educationType;
            Year = (int)educationType == 1 ? DateTime.Now.Year : DateTime.Now.Year + 1;
            IsActive = false;
        }

        #region prop
        public int Year { get; private set; }
        public PeriodType PeriodType { get; private set; }
        public EducationType EducationType { get; private set; }
        public int WeeklyHour { get; private set; }
        public bool IsActive { get; private set; } = false;
        public long DepartmentId { get; private set; }
        public virtual DepartmentEntity Department { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime UpdatedDate { get; private set; } = DateTime.Now;

        public virtual List<UnitLessonEntity> UnitLessons { get; private set; } = new List<UnitLessonEntity>();
        #endregion

        public void AddUnitLesson(UnitLessonEntity unitLessons)
        {
            UnitLessons.Add(unitLessons);
        }
        #region DEFAULT PROGRAM OLUŞTURMA
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
                for (int j = startTime; j < endTime; j++)
                {
                    var unitLessonDomain = UnitLessonDomainFactory.Create();
                    unitLessonDomain.AddTime((DayOfTheWeekType)i, j, j + 1);
                    var unitEntity = unitLessonDomain.Map<UnitLessonEntity>();
                    AddUnitLesson(unitEntity);
                }
            }
        }
        #endregion

        #region DERS ATAMA
        public void AssignToLesson(IList<SyllabusForLessonWithGroupListDto> lessons, CreateSyllabusRequest request)
        {
            lessons.Shuffle();
            var lesson = lessons.First();
            while (lessons.Count != 0)
            {
                foreach (var group in lesson.LessonGroups)
                {
                    AssignLessonCheckCriteria(lesson, group.GroupType);
                }
                lessons.Remove(lesson);
                lessons.Shuffle();
                if (lessons.Count > 0)
                    lesson = lessons.First();
            }
        }
        private void AssignLessonCheckCriteria(SyllabusForLessonWithGroupListDto lesson, LessonGroupType groupType)
        {
            if (lesson.WeeklyHour > 2)
            {
                //3 saat ard arda ata
                if (lesson.WeeklyHour == 3)
                {
                    UnitAssignToLesson(lesson, 3, groupType);
                }
                else
                {
                    //2 saat art arda ata
                    UnitAssignToLesson(lesson, 2, groupType);
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
                {
                    //1 tane boş birim bul ata
                    UnitAssignToLesson(lesson, 1, groupType);
                }
                else
                {
                    // 2 tane aynı günde boş birim bul ard arda ata
                    UnitAssignToLesson(lesson, 2, groupType);
                }
            }
        }
        private void UnitAssignToLesson(SyllabusForLessonWithGroupListDto lesson, int hour, LessonGroupType groupType)
        {
            var emptyUnits = UnitEmptySearch(hour);
            var isEmpty = new List<UnitLessonEntity>();
            // index null gelirse yeni tablo oluşmuş demektir orda arama yapmak için
            if (emptyUnits.Count == 0)
                emptyUnits = UnitEmptySearch(hour);
            if (emptyUnits.Count > 0)
                isEmpty = UnitLessons.FindAll(x => x.DayOfTheWeekType == emptyUnits.First().DayOfTheWeekType && x.SemesterType == lesson.SemesterType  && x.GroupType == groupType);
            while (isEmpty.Count != 0)
            {
                if (emptyUnits.Count > 0)
                    isEmpty = UnitLessons.FindAll(x => x.DayOfTheWeekType == emptyUnits.First().DayOfTheWeekType && x.SemesterType == lesson.SemesterType && x.GroupType == groupType);
                if (isEmpty.Count > 0) {
                    emptyUnits = UnitEmptySearch(hour);
                    break;
                }
            }

            if (isEmpty.Count == 0)
            {
                int index = 0;
                emptyUnits.ForEach(unit =>
                {
                    index = UnitLessons.IndexOf(unit);
                    UnitLessons[index].LessonId = lesson.LessonId;
                    UnitLessons[index].SemesterType = lesson.SemesterType;
                    UnitLessons[index].GroupType = groupType;
                });
            }
        }
        private List<UnitLessonEntity> UnitEmptySearch(int hour)
        {
            var days = new List<DayOfTheWeekType> { DayOfTheWeekType.One, DayOfTheWeekType.Two, DayOfTheWeekType.Three, DayOfTheWeekType.Four, DayOfTheWeekType.Five };
            var units = GetEmptyUnitsForDay(days);
            var emptyUnit = new List<UnitLessonEntity>();

            //Bu kısımda dizide aranan sayıda boşluk var ise yerler değiştirilip uygun yer açılacak ard arda değil ise
            while (days.Count != 0)
            {
                if (units.Count == hour || units.Count > hour)
                {
                    emptyUnit = GetEmptyIndexForUnits(units, hour);
                    days.Remove(units.FirstOrDefault().DayOfTheWeekType);

                    if (emptyUnit.Count == 0)
                    {
                        units = GetEmptyUnitsForDay(days);
                        days.Remove(units.FirstOrDefault().DayOfTheWeekType);
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

            if (units != null)
            {
                if (hour == 3)
                {
                    for (int i = 0; i < units.Count - 2; i++)
                    {
                        if (units.ElementAtOrDefault(i).EndTime == units.ElementAtOrDefault(i + 1).StarTime && units.ElementAtOrDefault(i + 1).EndTime == units.ElementAtOrDefault(i + 2).StarTime)
                        {
                            empytUnit.Add(units.ElementAtOrDefault(i));
                            empytUnit.Add(units.ElementAtOrDefault(i + 1));
                            empytUnit.Add(units.ElementAtOrDefault(i + 2));
                            if (empytUnit.Count == hour)
                                return empytUnit;
                        }
                    }
                }
                if (hour == 2)
                {
                    for (int i = 0; i < units.Count - 1; i++)
                    {
                        if (units.ElementAtOrDefault(i).EndTime == units.ElementAtOrDefault(i + 1).StarTime)
                        {
                            empytUnit.Add(units.ElementAtOrDefault(i));
                            empytUnit.Add(units.ElementAtOrDefault(i + 1));
                            if (empytUnit.Count == hour)
                                return empytUnit;
                        }
                    }
                }
                if (hour == 1)
                {
                    units.Shuffle();
                    empytUnit.Add(units.FirstOrDefault());
                }
            }



            return empytUnit;
        }
        private List<UnitLessonEntity> GetEmptyUnitsForDay(List<DayOfTheWeekType> days)
        {
            days.Shuffle();
            var day = days.First();
            return UnitLessons.FindAll(x => x.LessonId == 0 && x.DayOfTheWeekType == day);
        }

        #endregion

        #region ÖĞRETMEN ATAMA
        public void AssignToTeacher(List<SyllabusForLessonWithGroupListDto> teacherForLesson, SyllabusForUserWithConstraintListDto teacher)
        {
            var emptyUnit = UnitLessons.FindAll(x => x.UserId == 0 && teacherForLesson.Contains(teacherForLesson.Find(y => y.LessonId == x.LessonId)));
            var days = emptyUnit.Select(x => x.DayOfTheWeekType).OrderBy(x => x).Distinct().ToList();

            if (teacher.Constraint != null)
            {
                if (teacher.Constraint.IsFreeDay && days.Count > 3)
                {
                    var units = TeacherConstraintFreeDayCase(emptyUnit, teacher, days);

                    if (units.Count > 0)
                        TaecherTitleControlAndAssign(units, teacher);
                    else
                        TaecherTitleControlAndAssign(emptyUnit, teacher);
                }
                else
                {
                    if (teacher.Constraint.StartTime != 0 && teacher.Constraint.EndTime != 0)
                    {
                        var filterByTimeUnit = emptyUnit.FindAll(x => x.StarTime == teacher.Constraint.StartTime && x.EndTime == teacher.Constraint.EndTime);
                        if (filterByTimeUnit.Count > 0)
                            TaecherTitleControlAndAssign(filterByTimeUnit, teacher);
                        else
                            TaecherTitleControlAndAssign(emptyUnit, teacher);
                    }
                    else
                    {
                        TaecherTitleControlAndAssign(emptyUnit, teacher);
                    }
                }
            }
            else
            {
                TaecherTitleControlAndAssign(emptyUnit, teacher);
            }
        }
        private List<UnitLessonEntity> TeacherConstraintFreeDayCase(List<UnitLessonEntity> emptyUnit, SyllabusForUserWithConstraintListDto teacher, List<DayOfTheWeekType> days)
        {
            var day = days.First();
            int randomDay = new Random().Next((int)day, (int)days.Last() - 2);

            var units = emptyUnit.FindAll(x => (int)x.DayOfTheWeekType == randomDay && (int)x.DayOfTheWeekType == randomDay + 2);
            if (teacher.Constraint.StartTime != 0 && teacher.Constraint.EndTime != 0)
                units = units.FindAll(x => x.StarTime == teacher.Constraint.StartTime && x.EndTime == teacher.Constraint.EndTime);
            if (units.Count == 0)
                units = emptyUnit.FindAll(x => (int)x.DayOfTheWeekType == randomDay && (int)x.DayOfTheWeekType == randomDay + 2);
            return units;
        }
        //Teacher Title göre once mecburi saat kadar ders ata
        private void TaecherTitleControlAndAssign(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            switch (teacher.Title)
            {
                case (Title.Profesor):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.Prof)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.DocentDoktor):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.Doc)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.YardimciDocent):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.YrDoc)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                case (Title.OgretimGorevlisi):
                    if (units.Count >= (int)CompulsoryLessonHoursForTitle.OgrGor)
                        TitleForMinUnitsAndAssignOnTeacher(units, teacher);
                    else
                        PlaceAssingToTeacher(units, teacher);
                    break;
                default:
                    PlaceAssingToTeacher(units, teacher);
                    break;
            }
        }
        //Title a göre atanacak dersler aynı güne ve ard arda mı geliyor ona göre atama yap    
        private void TitleForMinUnitsAndAssignOnTeacher(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            for (int i = 0; i < units.Count; i++)
            {
                var sameLessonUnits = units.FindAll(x => x.GroupType == units[i].GroupType && x.LessonId == units[i].LessonId && x.DayOfTheWeekType == units[i].DayOfTheWeekType);

                if (sameLessonUnits.Count == 3)
                {
                    if (sameLessonUnits.ElementAt(0).LessonId == sameLessonUnits.ElementAt(1).LessonId
                                && sameLessonUnits.ElementAt(0).EndTime == sameLessonUnits.ElementAt(1).StarTime
                                && sameLessonUnits.ElementAt(1).EndTime == sameLessonUnits.ElementAt(2).StarTime)
                    {
                        PlaceAssingToTeacher(sameLessonUnits, teacher);
                        units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType);
                    }
                }

                if (sameLessonUnits.Count == 2)
                {
                    if (sameLessonUnits.ElementAt(0).LessonId == sameLessonUnits.ElementAt(1).LessonId
                                   && sameLessonUnits.ElementAt(0).EndTime == sameLessonUnits.ElementAt(1).StarTime)
                    {
                        PlaceAssingToTeacher(sameLessonUnits, teacher);
                        units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                    }
                }

                if (sameLessonUnits.Count == 1)
                {
                    PlaceAssingToTeacher(sameLessonUnits, teacher);
                    units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                }

                if (sameLessonUnits.Count > 3)
                {
                    PlaceAssingToTeacher(sameLessonUnits, teacher);
                    units.RemoveAll(x => x.LessonId == sameLessonUnits.ElementAt(0).LessonId && x.GroupType == sameLessonUnits.ElementAt(0).GroupType && x.DayOfTheWeekType == sameLessonUnits.ElementAt(0).DayOfTheWeekType);
                }

                if (sameLessonUnits.Count == 0)
                    units.RemoveAt(i);
            }
        }
        private void PlaceAssingToTeacher(List<UnitLessonEntity> units, SyllabusForUserWithConstraintListDto teacher)
        {
            if (units.Count > 0)
            {
                var isSameDayThisTeacher = UnitLessons.FindAll(x => x.UserId == teacher.UserId && x.DayOfTheWeekType == units.First().DayOfTheWeekType && x.StarTime == units.First().StarTime);
                var isSameTeacherEndTime = UnitLessons.FindAll(x => x.UserId == teacher.UserId && x.DayOfTheWeekType == units.Last().DayOfTheWeekType && x.EndTime == units.Last().EndTime);

                if (isSameDayThisTeacher.Count == 0 && isSameTeacherEndTime.Count == 0)
                {
                    int index = 0;
                    units.ForEach(item =>
                     {
                         index = UnitLessons.IndexOf(item);
                         UnitLessons[index].UserId = teacher.UserId;
                     });
                } else {
                    //Çakısma var
                }
            }
        }

        #endregion

        #region DERSLİK ATAMA
        public void AssignToLocations(List<SyllabusForLocationListDto> locations)
        {
            var emptyLocationOnUnits = UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0);
            var tempLocations = locations.Map<List<SyllabusForLocationListDto>>();

            for (int i = (int)DayOfTheWeekType.One; i <= (int)DayOfTheWeekType.Five; i++)
            {
                var sameDayUnits = emptyLocationOnUnits.FindAll(x => x.DayOfTheWeekType == (DayOfTheWeekType)i);
                for (int j = 0; j < sameDayUnits.Count; j++)
                {
                    var units = sameDayUnits.FindAll(x => x.LessonId == sameDayUnits[j].LessonId && x.GroupType == sameDayUnits[j].GroupType && x.DayOfTheWeekType == sameDayUnits[j].DayOfTheWeekType);
                    if (locations.FirstOrDefault() != null)
                    {
                        PlaceLocationsOnUnits(units, locations.FirstOrDefault(), tempLocations);
                        ClearToAssignLocationOnUnit(units, sameDayUnits);
                        emptyLocationOnUnits = UnitLessons.FindAll(x => x.LessonId > 0 && x.UserId > 0 && x.LocationId == 0 && x.LocationId != locations.FirstOrDefault().LocationId);
                        locations.Remove(locations.FirstOrDefault());
                    }
                }
            }
        }
        private void ClearToAssignLocationOnUnit(List<UnitLessonEntity> units, List<UnitLessonEntity> sameDayUnits)
        {
            foreach (var item in units)
            {
                int index = sameDayUnits.IndexOf(item);
                sameDayUnits.RemoveAt(index);
            }
        }
        private void PlaceLocationsOnUnits(List<UnitLessonEntity> units, SyllabusForLocationListDto location, List<SyllabusForLocationListDto> tempLocations)
        {
            var isEmpty = units.FindAll(x => x.DayOfTheWeekType == units[0].DayOfTheWeekType && x.StarTime == units[0].StarTime && x.LocationId == location.LocationId);

            if (isEmpty.Count > 0)
            {
                tempLocations.Shuffle();
                AssignToLocations(tempLocations);
            }
            else
            {
                int index = 0;
                units.ForEach(item =>
                {
                    index = UnitLessons.IndexOf(item);
                    UnitLessons[index].LocationId = location.LocationId;
                });
            }
        }

        #endregion

        public void AddWeeklyHour(int weeklyHour)
        {
            WeeklyHour = weeklyHour;
        }
    }
}
