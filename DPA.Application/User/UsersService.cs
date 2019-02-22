using DotNetCore.Security;
using DPA.Database.Repositories.User;
using DPA.Database.UnitOfWork;

namespace DPA.Application.User
{
    public sealed class UsersService
    {
        public UsersService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IJsonWebToken jsonWebToken,
            IUserRepository userRepository
        )
        {
            
        }
    }
}