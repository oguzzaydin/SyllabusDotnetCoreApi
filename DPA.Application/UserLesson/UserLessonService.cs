using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

namespace DPA.Application
{
    public sealed class UserLessonService : IUserLessonService
    {
        public UserLessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLessonRepository userLessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;    
            UserLessonRepository = userLessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLessonRepository UserLessonRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddUserLessonModel addUserLessonModel)
        {
            var validation = new AddUserLessonModelValidator().Valid(addUserLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var userLessonDomain = UserLessonDomainFactory.Create(addUserLessonModel);

            var userLessonEntity = userLessonDomain.Map<UserLessonEntity>();

            await UserLessonRepository.AddAsync(userLessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(userLessonEntity.UserLessonId);
        }
    }
}