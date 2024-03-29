using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Domain.LessonGroup;
using DPA.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.Application
{
    public class LessonService : ILessonService
    {
        public LessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ILessonRepository lessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            LessonRepository = lessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private ILessonRepository LessonRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddLessonModel addLessonModel)
        {
            var validation = new LessonModelValidator().Valid(addLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var lessonDomain = LessonDomainFactory.Create(addLessonModel);

            lessonDomain.Add();

            var lessonEntity = lessonDomain.Map<LessonEntity>();

            addLessonModel.LessonGroupTypes.ForEach(x => {
                var domain = LessonGroupDomainFactory.Create(x, lessonEntity.LessonId);
                lessonEntity.LessonGroups.Add(domain.Map<LessonGroupEntity>());
            });

            await LessonRepository.AddAsync(lessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(lessonEntity.LessonId);
        }

        public async Task<IResult> DeleteAsync(long lessonId)
        {
            await LessonRepository.DeleteAsync(lessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<ListLessonModel>> ListAsync()
        {
            return await LessonRepository.ListAsync<ListLessonModel>();
        }

        public async Task<PagedList<ListLessonModel>> ListAsync(PagedListParameters parameters)
        {
            return await LessonRepository.ListAsync<ListLessonModel>(parameters);
        }

        public async Task<ListLessonModel> SelectAsync(long lessonId)
        {
            var lesson = await LessonRepository.FirstOrDefaultAsync<LessonEntity>(x => x.LessonId == lessonId);
            lesson.LessonGroups = await LessonRepository.FirstOrDefaultAsync(x => x.LessonId == lessonId, y => y.LessonGroups);
            var lessonModel = lesson.Map<ListLessonModel>();
            lessonModel.LessonGroups=lesson.LessonGroups.ToList().Map<List<LessonGroups>>();
            return lessonModel;
        }

        public async Task<IResult> UpdateAsync(long lessonId, UpdateLessonModel updateLessonModel)
        {
            var validation = new LessonModelValidator().Valid(updateLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var lessonEntity = await LessonRepository.SelectAsync(lessonId);

            var nullObjectValidation = new NullObjectValidation<LessonEntity>().Valid(lessonEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var lessonDomain = LessonDomainFactory.Create(lessonEntity);

            lessonDomain.Update(updateLessonModel);

            lessonEntity = lessonDomain.Map<LessonEntity>();

            lessonEntity.LessonId = lessonId;

            await LessonRepository.UpdateAsync(lessonEntity, lessonEntity.LessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}