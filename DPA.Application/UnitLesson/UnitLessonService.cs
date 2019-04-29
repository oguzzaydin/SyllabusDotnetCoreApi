using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Database.Repositories.UnitLesson;
using DPA.Domain.UnitLesson;
using DPA.Model;

namespace DPA.Application.UnitLesson
{
    public class UnitLessonService : IUnitLessonService
    {
        #region .ctor
        private readonly IDatabaseUnitOfWork _databaseUnitOfWork;
        private readonly IUnitLessonRepository _unitLessonRepository;

        public UnitLessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUnitLessonRepository unitLessonRepository
        )
        {
            _databaseUnitOfWork = databaseUnitOfWork;
            _unitLessonRepository = unitLessonRepository;
        }
        #endregion 
        public async Task<IResult> UpdateAsync(UpdateUnitLessonModel request)
        {
            Check.NotNullOrEmpty(request, "request");
            var validation = new UpdateUnitLessonModelValidator().Valid(request);
            if (!validation.Success)
            {
                new ErrorDataResult<long>(validation.Message);
            }
            var unitLessonEntity = await _unitLessonRepository.SelectAsync(request.UnitLessonId);
            var unitLessonDomain = UnitLessonDomainFactory.Create(unitLessonEntity);
            unitLessonDomain.Update(request);
            unitLessonEntity = unitLessonDomain.Map<UnitLessonEntity>();

            await _unitLessonRepository.UpdateAsync(unitLessonEntity, unitLessonEntity.UnitLessonId);
            await _databaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}