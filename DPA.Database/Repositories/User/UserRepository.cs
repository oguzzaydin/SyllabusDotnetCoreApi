using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using DPA.Model;
using DPA.Model.Models.UserModel.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public List<SyllabusForUserWithConstraintListDto> GetUserWithConstraintsForLesson(long lessonId)
        {
            var users = Queryable.FromSql($@"SELECT u.* FROM Faculty.Lesson as l
                                    INNER JOIN [User].UserLesson ul on l.LessonId = {lessonId} and ul.LessonId = l.LessonId
                                    INNER JOIN [User].[User] as u on u.UserId = ul.UserId");
            var userConstraints = users.Include(x => x.Constraints).ToList();
            
            // if (userConstraints.Count == 0)
            //     throw new UserFriendlyException($"{lessonId} Id li derse ait hoca bulunamadı.");
            
            return userConstraints.Map<List<SyllabusForUserWithConstraintListDto>>();
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