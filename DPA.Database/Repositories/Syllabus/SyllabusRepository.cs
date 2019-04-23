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
    }
}