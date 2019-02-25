using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

namespace DPA.Application
{
    public sealed class DepartmanLessonService : IDepartmanLessonService
    {
        public DepartmanLessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IDepartmanLessonRepository departmanLessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;    
            DepartmanLessonRepository = departmanLessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IDepartmanLessonRepository DepartmanLessonRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddDepartmanLessonModel addDepartmanLessonModel)
        {
            var validation = new AddDepartmanLessonModelValidator().Valid(addDepartmanLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var departmanLessonDomain = DepartmanLessonDomainFactory.Create(addDepartmanLessonModel);

            var DepartmanLessonEntity = departmanLessonDomain.Map<DepartmanLessonEntity>();

            await DepartmanLessonRepository.AddAsync(DepartmanLessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(DepartmanLessonEntity.DepartmanLessonId);
        }
    }
}