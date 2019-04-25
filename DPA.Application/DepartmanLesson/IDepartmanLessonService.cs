using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IDepartmentLessonService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmentLessonModel addDepartmentLessonModel);
        Task<IEnumerable<ListLessonModel>> ListLessonAsync(long DepartmentId);
        Task<IEnumerable<ListDepartmentModel>> ListDepartmentAsync(long lessonId);
        Task<IResult> DeleteLessonAsync(long DepartmentId, long lessonId);
        Task<IResult> UpdateLessonAsync(long lessonId, UpdateDepartmentLessonModel updateDepartmentLessonModel);
        Task<IResult> UpdateDepartmentAsync(long DepartmentId, UpdateDepartmentLessonModel updateDepartmentLessonModel);
    }
}