using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface ILessonService
    {
        Task<IDataResult<long>> AddAsync(AddLessonModel addLessonModel);

        Task<IResult> DeleteAsync(long lessonId);

        Task<IEnumerable<LessonModel>> ListAsync();

        Task<PagedList<LessonModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long lessonId, UpdateLessonModel updateLessonModel);

        Task<LessonModel> SelectAsync(long lessonId);
    }
}