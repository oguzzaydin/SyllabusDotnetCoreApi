using System.Threading.Tasks;
using DotNetCore.EntityFrameworkCore;
using DPA.Database.Database;
using DPA.Model.Entities;
using DPA.Model.Enums;
using DPA.Model.Models.SignedInModel;
using DPA.Model.Models.SignInModel;

namespace DPA.Database.Repositories.User
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<SignedInModel> SignInAsync(SignInModel signInModel)
        {
           return FirstOrDefaultAsync<SignedInModel>
           (
               userEntity => userEntity.UserName.Equals(signInModel.UserName)
               && userEntity.Password.Equals(signInModel.Password)
               && userEntity.Status == Status.Active
           );
        }
    }
}
