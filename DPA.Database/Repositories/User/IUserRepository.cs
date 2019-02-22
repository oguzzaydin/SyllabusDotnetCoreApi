using System.Threading.Tasks;
using DotNetCore.Repositories;
using DPA.Model.Entities;
using DPA.Model.Models;
using DPA.Model.Models.SignedInModel;
using DPA.Model.Models.SignInModel;

namespace DPA.Database.Repositories.User
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel);
    }
}
