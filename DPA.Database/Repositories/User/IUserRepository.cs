using DotNetCore.Repositories;
using DPA.Model.Entities;

namespace DPA.Database.Repositories.User
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        //Task<SignedInModel> SignInAsync(SignInModel signInModel);
    }
}
