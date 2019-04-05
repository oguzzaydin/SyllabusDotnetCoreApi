using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IResult> DeleteLessonAsync(long departmanId, long lessonId)
        {
            await DepartmanLessonRepository.DeleteAsync(x => x.DepartmanId == departmanId && x.LessonId == lessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<ListDepartmanModel>> ListDepartmanAsync(long lessonId)
        {
            var departmanLesson = await DepartmanLessonRepository.ListAsync<DepartmanLessonEntity>(x => x.LessonId == lessonId, y => y.Departman);

            return departmanLesson.Select(x => x.Departman).Map<IEnumerable<ListDepartmanModel>>();
        }

        public async Task<IEnumerable<ListLessonModel>> ListLessonAsync(long departmanId)
        {
            var departmanLesson = await DepartmanLessonRepository.ListAsync<DepartmanLessonEntity>(x => x.DepartmanId == departmanId, y => y.Lesson);

            return departmanLesson.Select(x => x.Lesson).Map<IEnumerable<ListLessonModel>>();
        }

        public async Task<IResult> UpdateLessonAsync(long lessonId, UpdateDepartmanLessonModel updateDepartmanLessonModel)
        {
            return await Update(updateDepartmanLessonModel, x => x.DepartmanId == updateDepartmanLessonModel.DepartmanId && x.LessonId == lessonId).ConfigureAwait(false);;
        }

        public async Task<IResult> UpdateDepartmanAsync(long departmanId, UpdateDepartmanLessonModel updateDepartmanLessonModel)
        {
            return await Update(updateDepartmanLessonModel, x => x.LessonId == updateDepartmanLessonModel.LessonId && x.DepartmanId == departmanId).ConfigureAwait(false);;
        }

        private async Task<IResult> Update(UpdateDepartmanLessonModel updateDepartmanLessonModel, Expression<Func<DepartmanLessonEntity, bool>> where)
        {
            var validation = new UpdateDepartmanLessonModelValidator().Valid(updateDepartmanLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var departmanLessonEntity = await DepartmanLessonRepository.SingleOrDefaultAsync(where);
            
            var nullObjectValidation = new NullObjectValidation<DepartmanLessonEntity>().Valid(departmanLessonEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var departmanLessonDomain = DepartmanLessonDomainFactory.Create(departmanLessonEntity);

            departmanLessonDomain.Update(updateDepartmanLessonModel);

            departmanLessonEntity = departmanLessonDomain.Map<DepartmanLessonEntity>();

            await DepartmanLessonRepository.UpdateAsync(departmanLessonEntity, departmanLessonEntity.DepartmanLessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

    }
}