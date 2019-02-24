using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;

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

            await LessonRepository.AddAsync(lessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();
            
            return new SuccessDataResult<long>(lessonEntity.Id);
        }

        public async Task<IResult> DeleteAsync(long lessonId)
        {
            await LessonRepository.DeleteAsync(lessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<LessonModel>> ListAsync()
        {
            return await LessonRepository.ListAsync<LessonModel>();
        }

        public async Task<PagedList<LessonModel>> ListAsync(PagedListParameters parameters)
        {
            return await LessonRepository.ListAsync<LessonModel>(parameters);
        }

        public async Task<LessonModel> SelectAsync(long lessonId)
        {
            return await LessonRepository.SelectAsync<LessonModel>(lessonId);
        }

        public async Task<IResult> UpdateAsync(long lessonId, UpdateLessonModel updateLessonModel)
        {
            var validation = new LessonModelValidator().Valid(updateLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var lessonEntity = await LessonRepository.SelectAsync(lessonId);

            var lessonDomain = LessonDomainFactory.Create(lessonEntity);

            lessonDomain.Update(updateLessonModel);

            lessonEntity = lessonDomain.Map<LessonEntity>();

            await LessonRepository.UpdateAsync(lessonEntity, lessonEntity.Id);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}