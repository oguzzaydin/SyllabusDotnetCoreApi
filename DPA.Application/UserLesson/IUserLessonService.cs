using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface IUserLessonService
    {
        Task<IDataResult<long>> AddAsync(AddUserLessonModel addUserLessonModel);
    }
}