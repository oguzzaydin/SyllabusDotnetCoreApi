using DotNetCore.Repositories;
using DPA.Model;
using DPA.Model.Models.UserModel.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        List<SyllabusForUserWithConstraintListDto> GetUserWithConstraintsForLesson(long lessonId);
        Task<SignedInModel> SignInAsync(SignInModel signInModel);
    }
}