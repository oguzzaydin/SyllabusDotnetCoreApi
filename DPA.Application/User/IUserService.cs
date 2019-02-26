using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IUserService
    {
        Task<IDataResult<long>> AddAsync(AddUserModel addUserModel);

        Task<IResult> DeleteAsync(long userId);

        Task<IDataResult<SignedInModel>> SignInAsync(SignInModel signInModel);

        Task<IDataResult<TokenModel>> SignInJwtAsync(SignInModel signInModel);

        Task<IResult> UpdateAsync(long userId, UpdateUserModel updateUserModel);

        Task<IEnumerable<UserModel>> ListAsync();

        Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters);

        Task<UserModel> SelectAsync(long userId);

        Task SignOutAsync(SignOutModel signOutModel);
    }
}