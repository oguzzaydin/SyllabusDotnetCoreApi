using System.Collections.Generic;

namespace DPA.Model
{
    public class SyylabusForDepartmentDTo
    {
        public long SyllabusId { get; set; }
        public int Year { get; set; }
        public PeriodType PeriodType { get; set; }
        public EducationType EducationType { get; set; }
        public long DepartmentId { get; set; }
        public int WeeklyHour { get; set; }
        public ICollection<UnitLessonDto> UnitLessons { get; set; } = new HashSet<UnitLessonDto>();
    }

    public class UnitLessonDto
    {
        public long UnitLessonId { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public LessonGroupType GroupType { get; set; }
        public EducationType EducationType { get; set; }
        public DayOfTheWeekType DayOfTheWeekType { get; set; }
        public LessonDto Lesson { get; set; }
        public TeacherDto User { get; set; }
        public LocationDto Location { get; set; }
    }

    public class LessonDto
    {
        public long LessonId { get; set; }
        public string Name { get; set; }
        public string LessonCode { get; set; }
        public int AKTS { get; set; }
        public int Credit { get; set; }
        public int WeeklyHour { get; set; }
        public SemesterType SemesterType { get; set; }
        public LessonType LessonType { get; set; }
    }

    public class TeacherDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Roles Roles { get; set; }
        public Status Status { get; set; }
        public Title Title { get; set; }
    }

    public class LocationDto
    {
        public long LocationId { get; set; }
        public string Title { get; set; }
    }
}