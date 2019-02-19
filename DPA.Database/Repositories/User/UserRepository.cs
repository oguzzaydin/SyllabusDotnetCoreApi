using DotNetCore.EntityFrameworkCore;
using DPA.Database.Database;
using DPA.Model.Entities;

namespace DPA.Database.Repositories.User
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        //public Task<SignedInModel> SignInAsync(SignInModel signInModel)
        //{
        //    return FirstOrDefaultAsync<SignedInModel>
        //    (
        //        userEntity => userEntity.Login.Equals(signInModel.Login)
        //        && userEntity.Password.Equals(signInModel.Password)
        //        && userEntity.Status == Status.Active
        //    );
        //}
    }
}
