using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using DPA.Database.Exceptions;
using DPA.Model;
using DPA.Model.Extensions;
using DPA.Model.Models.SyllabusModel.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public sealed class LessonRepository : EntityFrameworkCoreRepository<LessonEntity>, ILessonRepository
    {
        public LessonRepository(DatabaseContext context) : base(context)
        {
        }
        public List<SyllabusForLessonWithGroupListDto> GetDepartmentLessons(long facultyId, long departmentId, SemesterType semesterType)
        {
            var lessons = Queryable.FromSql($@"SELECT l.* FROM Faculty.Department as d
                        INNER JOIN Faculty.DepartmentLesson dl on ( d.FacultyId = {facultyId} and d.DepartmentId = {departmentId} ) and d.DepartmentId = dl.DepartmentId
                        INNER JOIN Faculty.Lesson l on l.SemesterType = {(int)semesterType} and dl.LessonId = l.LessonId");
            var lessonGroups = lessons.Include(x => x.LessonGroups).ToList();

            if (lessonGroups.Count == 0)
                throw new UserFriendlyException("Seçiminize uygun dersler bulunamadı.");

            lessonGroups.Shuffle();
            return lessonGroups.Map<List<SyllabusForLessonWithGroupListDto>>();
        }

        public List<LessonEntity> GetLessonsForTeacher(long userId)
        {
            var lessons = Queryable.FromSql($@"SELECT DISTINCT l.* FROM Faculty.Lesson as l
                            INNER JOIN [User].UserLesson ul on ul.LessonId = l.LessonId
                            INNER JOIN [User].[User] as u on u.UserId = ul.UserId and u.UserId = {userId}").ToList();

            // if (lessons.Count == 0)
            //     throw new UserFriendlyException("Seçiminize uygun dersler bulunamadı.");
            return lessons;
        }
    }
}