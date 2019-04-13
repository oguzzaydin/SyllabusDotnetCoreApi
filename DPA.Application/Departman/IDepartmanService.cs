using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IDepartmentService
    {
        Task<IDataResult<long>> AddAsync(AddDepartmentModel addDepartmentModel);

        Task<IResult> DeleteAsync(long departmentId);

        Task<IEnumerable<ListDepartmentModel>> ListAsync();

        Task<PagedList<ListDepartmentModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long departmentId, UpdateDepartmentModel updateDepartmentModel);

        Task<IResult> UpdateUserAsync(long departmentId, long userId);

        Task<DepartmentModel> SelectAsync(long departmentId);

        Task<UserModel> SingleOrDefaultUserAsync(long departmentId);

        Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long departmentId);

        Task<ListDepartmentModel> GetDepartmentForHeadOfDepartmentAsync(long headheadOfDepartmentId);
    }
}