using DotNetCore.Mapping;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class UserLogService : IUserLogService
    {
        public UserLogService
        (
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLogRepository userLogRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLogRepository = userLogRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLogRepository UserLogRepository { get; }

        public async Task AddAsync(UserLogModel userLogModel)
        {
            var userLogDomain = UserLogDomainFactory.Create(userLogModel);
            userLogDomain.Add();

            var userLogEntity = userLogDomain.Map<UserLogEntity>();

            await UserLogRepository.AddAsync(userLogEntity);
            await DatabaseUnitOfWork.SaveChangesAsync();
        }
    }
}
