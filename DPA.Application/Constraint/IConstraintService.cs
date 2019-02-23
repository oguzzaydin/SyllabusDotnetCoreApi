using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface IConstraintService
    {
        Task<IDataResult<long>> AddAsync(AddConstraintModel addConstraintModel);

        Task<IResult> DeleteAsync(long constraintId);

        Task<IEnumerable<ConstraintModel>> ListAsync();

        Task<PagedList<ConstraintModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel);

        Task<ConstraintModel> SelectAsync(long constraintId);

    }
}