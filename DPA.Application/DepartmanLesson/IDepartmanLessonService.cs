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
    }
}