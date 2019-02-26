using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IDepartmanLessonService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmanLessonModel addDepartmanLessonModel);

        Task<IEnumerable<LessonModel>> ListLessonAsync(long departmanId);

        Task<IEnumerable<DepartmanModel>> ListDepartmanAsync(long lessonId);

        Task<IResult> DeleteLessonAsync(long departmanId, long lessonId);

        Task<IResult> UpdateLessonAsync(long lessonId, UpdateDepartmanLessonModel updateDepartmanLessonModel);

        Task<IResult> UpdateDepartmanAsync(long departmanId, UpdateDepartmanLessonModel updateDepartmanLessonModel);
    }
}