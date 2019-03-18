using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface ILessonService
    {
        Task<IDataResult<long>> AddAsync(AddLessonModel addLessonModel);

        Task<IResult> DeleteAsync(long lessonId);

        Task<IEnumerable<ListLessonModel>> ListAsync();

        Task<PagedList<ListLessonModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long lessonId, UpdateLessonModel updateLessonModel);

        Task<LessonModel> SelectAsync(long lessonId);
    }
}