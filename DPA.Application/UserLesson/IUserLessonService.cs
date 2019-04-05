using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IUserLessonService
    {
        Task<IDataResult<long>> AddAsync(AddUserLessonModel addUserLessonModel);
        
        Task<IEnumerable<ListLessonModel>> ListLessonAsync(long userId);

        Task<IEnumerable<ListUserModel>> ListInstructorAsync(long lessonId);

        Task<IResult> DeleteLessonAsync(long userId, long lessonId);

        Task<IResult> UpdateLessonAsync(long lessonId, UpdateUserLessonModel updateUserLessonModel);

        Task<IResult> UpdateInstructorAsync(long userId, UpdateUserLessonModel updateUserLessonModel);
    }
}