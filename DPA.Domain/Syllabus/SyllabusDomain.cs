using System;
using System.Collections.Generic;
using DPA.Model;

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

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; private set; } = new HashSet<UnitLessonEntity>();

        public void AddUnitLesson(UnitLessonEntity unitLessons) {
            UnitLessons.Add(unitLessons);
        }
    }
}
