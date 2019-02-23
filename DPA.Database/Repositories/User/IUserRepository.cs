using System.Threading.Tasks;
using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel); 
    }
}