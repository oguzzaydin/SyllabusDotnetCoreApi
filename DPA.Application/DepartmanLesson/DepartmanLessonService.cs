using System.Collections.Generic;
using System.Linq;
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
            IDepartmanLessonRepository departmanLessonRepository,
            ILessonRepository lessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            DepartmanLessonRepository = departmanLessonRepository;
            LessonRepository = lessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IDepartmanLessonRepository DepartmanLessonRepository { get; }
        private ILessonRepository LessonRepository { get; }

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

        public async Task<IEnumerable<LessonModel>> ListLessonAsync(long departmanId)
        {
            var departmanLesson = await DepartmanLessonRepository.ListAsync<DepartmanLessonEntity>(x => x.DepartmanId == departmanId, y => y.Lesson);

            return departmanLesson.Select(x => x.Lesson).Map<IEnumerable<LessonModel>>();
        }

    }
}