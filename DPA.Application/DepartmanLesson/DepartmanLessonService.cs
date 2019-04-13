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
    public sealed class DepartmentLessonService : IDepartmentLessonService
    {
        public DepartmentLessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IDepartmentLessonRepository departmentLessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            DepartmentLessonRepository = departmentLessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IDepartmentLessonRepository DepartmentLessonRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddDepartmentLessonModel addDepartmentLessonModel)
        {
            var validation = new AddDepartmentLessonModelValidator().Valid(addDepartmentLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var DepartmentLessonDomain = DepartmentLessonDomainFactory.Create(addDepartmentLessonModel);

            var DepartmentLessonEntity = DepartmentLessonDomain.Map<DepartmentLessonEntity>();

            await DepartmentLessonRepository.AddAsync(DepartmentLessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(DepartmentLessonEntity.DepartmentLessonId);
        }

        public async Task<IResult> DeleteLessonAsync(long DepartmentId, long lessonId)
        {
            await DepartmentLessonRepository.DeleteAsync(x => x.DepartmentId == DepartmentId && x.LessonId == lessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<ListDepartmentModel>> ListDepartmentAsync(long lessonId)
        {
            var DepartmentLesson = await DepartmentLessonRepository.ListAsync<DepartmentLessonEntity>(x => x.LessonId == lessonId, y => y.Department);

            return DepartmentLesson.Select(x => x.Department).Map<IEnumerable<ListDepartmentModel>>();
        }

        public async Task<IEnumerable<ListLessonModel>> ListLessonAsync(long DepartmentId)
        {
            var DepartmentLesson = await DepartmentLessonRepository.ListAsync<DepartmentLessonEntity>(x => x.DepartmentId == DepartmentId, y => y.Lesson);

            return DepartmentLesson.Select(x => x.Lesson).Map<IEnumerable<ListLessonModel>>();
        }

        public async Task<IResult> UpdateLessonAsync(long lessonId, UpdateDepartmentLessonModel updateDepartmentLessonModel)
        {
            return await Update(updateDepartmentLessonModel, x => x.DepartmentId == updateDepartmentLessonModel.DepartmentId && x.LessonId == lessonId).ConfigureAwait(false);;
        }

        public async Task<IResult> UpdateDepartmentAsync(long DepartmentId, UpdateDepartmentLessonModel updateDepartmentLessonModel)
        {
            return await Update(updateDepartmentLessonModel, x => x.LessonId == updateDepartmentLessonModel.LessonId && x.DepartmentId == DepartmentId).ConfigureAwait(false);;
        }

        private async Task<IResult> Update(UpdateDepartmentLessonModel updateDepartmentLessonModel, Expression<Func<DepartmentLessonEntity, bool>> where)
        {
            var validation = new UpdateDepartmentLessonModelValidator().Valid(updateDepartmentLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var DepartmentLessonEntity = await DepartmentLessonRepository.SingleOrDefaultAsync(where);
            
            var nullObjectValidation = new NullObjectValidation<DepartmentLessonEntity>().Valid(DepartmentLessonEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var DepartmentLessonDomain = DepartmentLessonDomainFactory.Create(DepartmentLessonEntity);

            DepartmentLessonDomain.Update(updateDepartmentLessonModel);

            DepartmentLessonEntity = DepartmentLessonDomain.Map<DepartmentLessonEntity>();

            await DepartmentLessonRepository.UpdateAsync(DepartmentLessonEntity, DepartmentLessonEntity.DepartmentLessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

    }
}