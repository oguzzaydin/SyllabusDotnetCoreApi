using DotNetCore.EntityFrameworkCore;
using DPA.Database.Database;
using DPA.Model.Entities;


namespace DPA.Database.Repositories.UserLog
{
    public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
