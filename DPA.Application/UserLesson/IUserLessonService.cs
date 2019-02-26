using DotNetCore.Objects;
using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IUserLessonService
    {
        Task<IDataResult<long>> AddAsync(AddUserLessonModel addUserLessonModel);
    }
}