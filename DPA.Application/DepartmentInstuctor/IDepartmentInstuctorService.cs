using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application.DepartmentInstuctor
{
    public interface IDepartmentInstuctorService
    {
        Task<IDataResult<long>> AddAsync(DepartmentInstructorModel request);
        Task<IEnumerable<ListUserModel>> ListInstructorAsync(long departmentId);
        Task<IResult> DeleteInstructorAsync(long departmentId, long userId);
    }
}