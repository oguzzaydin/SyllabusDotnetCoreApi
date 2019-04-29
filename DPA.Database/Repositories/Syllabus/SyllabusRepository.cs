using System.Collections.Generic;
using System.Linq;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using DPA.Database.Exceptions;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public class SyllabusRepository : EntityFrameworkCoreRepository<SyllabusEntity>, ISyllabusRepository
    {
        public SyllabusRepository(DatabaseContext context) : base(context)
        {
        }

        public SyylabusForDepartmentDTo GetSyllabusForDepartment(long departmentId)
        {
            var syllabuses = Queryable.FromSql($@"SELECT DISTINCT * FROM [Syllabus].[Syllabus] as s
                    INNER JOIN [Syllabus].[UnitLesson] as su on su.SyllabusId = s.SyllabusId
                    INNER JOIN [Faculty].[Lesson] as fl on su.LessonId = fl.LessonId  
                    INNER JOIN [Faculty].[Location] as fll on su.LocationId = fll.LocationId
                    INNER JOIN [User].[User] as u on u.UserId = su.UserId").ToList();

            if (syllabuses.Count == 0)
                throw new UserFriendlyException("Bölüme ait ders programı bulunamadı.");
            return syllabuses.Map<SyylabusForDepartmentDTo>(); ;
        }


        public SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId)
        {
            var syllabuses = Queryable.FromSql(QueryString("d.FirstActiveSyllabusId", departmentId));

            var syllabusesWithUnits = syllabuses.Include(x => x.UnitLessons)
                                     .ThenInclude(l => l.Lesson)
                                     .Include(x => x.UnitLessons)
                                     .ThenInclude(x => x.Location)
                                     .Include(x => x.UnitLessons)
                                     .ThenInclude(x => x.User)
                                     .ToList()
                                     .FirstOrDefault();


            if (syllabusesWithUnits == null)
                throw new UserFriendlyException("Bölüme ait 1.Ogretim ders programı bulunamadı.");
            return syllabusesWithUnits.Map<SyylabusForDepartmentDTo>();
        }

        public SyylabusForDepartmentDTo GetSecondSyllabusForDepartment(long departmentId)
        {
            var syllabuses = Queryable.FromSql(QueryString("d.SecondActiveSyylabusId", departmentId));

            var syllabusesWithUnits = syllabuses.Include(x => x.UnitLessons)
                                     .ThenInclude(l => l.Lesson)
                                     .Include(x => x.UnitLessons)
                                     .ThenInclude(x => x.Location)
                                     .Include(x => x.UnitLessons)
                                     .ThenInclude(x => x.User)
                                     .ToList()
                                     .FirstOrDefault();


            if (syllabusesWithUnits == null)
                throw new UserFriendlyException("Bölüme ait 2.Ogretim  ders programı bulunamadı.");
            return syllabusesWithUnits.Map<SyylabusForDepartmentDTo>();
        }

        private string QueryString(string query, long departmentId)
        {
            return $@"SELECT DISTINCT TOP (1) s.*,
                su.StarTime, su.EndTime, su.GroupType, su.DayOfTheWeekType,
                fl.LessonId, fl.[Name] as lessonName, fl.LessonCode, fl.AKTS, fl.Credit, fl.WeeklyHour as LessonWeeklyHour,
                fl.SemesterType, u.UserId, u.[Name] as firstName, u.Surname as lastName, u.Email, u.Roles,
                u.Title, fll.LocationId, fll.Title as LocationName
                FROM Faculty.Department as d
                INNER JOIN [Syllabus].[Syllabus] as s on s.DepartmentId = {departmentId} and s.SyllabusId = {query}
                INNER JOIN [Syllabus].[UnitLesson] as su on su.SyllabusId = s.SyllabusId
                INNER JOIN [Faculty].[Lesson] as fl on su.LessonId = fl.LessonId  
                INNER JOIN [Faculty].[Location] as fll on su.LocationId = fll.LocationId
                INNER JOIN [User].[User] as u on u.UserId = su.UserId";
        }
    }
}