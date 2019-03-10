using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface IConstraintService
    {
        Task<IDataResult<long>> AddAsync(AddConstraintModel addConstraintModel);

        Task<IResult> DeleteAsync(long constraintId);

        Task<IEnumerable<ListConstraintModel>> ListAsync();

        Task<PagedList<ListConstraintModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel);

        Task<ListConstraintModel> SelectAsync(long constraintId);
    }
}