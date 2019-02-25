using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface IDepartmanLessonService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmanLessonModel addDepartmanLessonModel);

        Task<IDataResult<LessonEntity>> ListLessonAsync(long departmanId);
    }
}