using DotNetCore.Repositories;
using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel);
    }
}