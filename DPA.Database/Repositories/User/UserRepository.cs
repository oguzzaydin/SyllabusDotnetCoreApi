using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using DPA.Model;
using DPA.Model.Models.UserModel.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Model.Models.SyllabusModel.Dtos;

namespace DPA.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public List<SyllabusForUserWithConstraintListDto> GetUserWithConstraintsForLesson(long lessonId)
        {
            var users = Queryable.FromSql($@"SELECT c.StartTime, c.EndTime, c.IsFreeDay, c.WeeklyHour, c.EducationType, u.* FROM Faculty.Lesson as l
                                    INNER JOIN [User].UserLesson ul on l.LessonId = {lessonId} and ul.LessonId = l.LessonId
                                    INNER JOIN [User].[User] as u on u.UserId = ul.UserId
                                    LEFT JOIN [User].[Constraint] as c on c.UserId = ul.UserId and u.UserId = c.UserId");
            var userConstraint = users.Include(x => x.Constraint).ToList();
            // if (userConstraints.Count == 0)
            //     throw new UserFriendlyException($"{lessonId} Id li derse ait hoca bulunamadı.");
            
            return userConstraint.Map<List<SyllabusForUserWithConstraintListDto>>();
        }

        public List<TeacherConstraintWithLessonsDto> GetTeacherConstraintWithLessons(long departmentId)
        {
            var users = Queryable.FromSql($@"SELECT DISTINCT c.StartTime, c.EndTime, c.IsFreeDay, c.WeeklyHour as ConstraintWeeklyHour, c.EducationType, 
                                l.LessonId, l.WeeklyHour as LessonWeeklyHour, l.LessonCode, l.[Name] as LessonName, l.SemesterType,
                                l.Credit, l.LessonType, u.* FROM Faculty.Lesson as l
                                INNER JOIN [User].UserLesson ul on  ul.LessonId = l.LessonId
                                INNER JOIN Department.DepartmentInstructor as di on di.DepartmentId = {departmentId}
                                INNER JOIN [User].[User] as u on u.UserId = ul.UserId
                                LEFT JOIN [User].[Constraint] as c on c.UserId = ul.UserId and u.UserId = c.UserId");

            var usersLessonsAndConstraint = users.Include(x => x.Constraint)
                .Include(x => x.UserLessons)
                .ThenInclude(x => x.Lesson).ToList();

            // if (userConstraints.Count == 0)
            //     throw new UserFriendlyException($"{lessonId} Id li derse ait hoca bulunamadı.");

            return usersLessonsAndConstraint.Map<List<TeacherConstraintWithLessonsDto>>();
        }

        public Task<SignedInModel> SignInAsync(SignInModel signInModel)
        {
            return SingleOrDefaultAsync<SignedInModel>
            (
                userEntity => userEntity.Login.Equals(signInModel.Login)
                && userEntity.Password.Equals(signInModel.Password)
                && userEntity.Status == Status.Active
            );
        }
    }
}