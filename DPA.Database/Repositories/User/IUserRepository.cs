using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Database
{
    public interface IUserRepository
    {
        Task<SignedInModel> SignInAsync(SignInModel signInModel); 
    }
}