using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IDepartmanLessonService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmanLessonModel addDepartmanLessonModel);

        Task<IEnumerable<ListLessonModel>> ListLessonAsync(long departmanId);

        Task<IEnumerable<ListDepartmanModel>> ListDepartmanAsync(long lessonId);

        Task<IResult> DeleteLessonAsync(long departmanId, long lessonId);

        Task<IResult> UpdateLessonAsync(long lessonId, UpdateDepartmanLessonModel updateDepartmanLessonModel);

        Task<IResult> UpdateDepartmanAsync(long departmanId, UpdateDepartmanLessonModel updateDepartmanLessonModel);
    }
}