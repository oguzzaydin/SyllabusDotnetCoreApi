using DotNetCore.Objects;
using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IUserService
    {
        Task<IDataResult<SignedInModel>> SignInAsync(SignInModel signInModel);

        Task<IDataResult<TokenModel>> SignInJwtAsync(SignInModel signInModel);

        //Task SignOutAsync(SignOutModel signOutModel);
    }
}