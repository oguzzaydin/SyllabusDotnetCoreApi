using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.EntityFrameworkCore;
using DPA.Database.Exceptions;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public sealed class LessonRepository : EntityFrameworkCoreRepository<LessonEntity>, ILessonRepository
    {
        public LessonRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LessonEntity>> GetDepartmentLessons(long facultyId, long departmentId, SemesterType semesterType)
        {

            var result = await Queryable.FromSql($@"SELECT l.* FROM Faculty.Department as d
                        INNER JOIN Faculty.DepartmentLesson dl on ( d.FacultyId = {facultyId} and d.DepartmentId = {departmentId} ) and d.DepartmentId = dl.DepartmentId
                        INNER JOIN Faculty.Lesson l on l.SemesterType = {(int)semesterType} and dl.LessonId = l.LessonId").ToListAsync();
            if (result.Count == 0)
                throw new UserFriendlyException("Seçiminize uygun dersler bulunamadı.");

            return result;
        }
    }
}