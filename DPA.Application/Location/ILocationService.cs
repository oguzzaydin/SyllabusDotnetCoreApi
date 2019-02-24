using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public interface ILocationService
    {
        Task<IDataResult<long>> AddAsync(AddLocationModel addLocationModel);

        Task<IResult> DeleteAsync(long locationId);

        Task<IEnumerable<LocationModel>> ListAsync();

        Task<PagedList<LocationModel>> ListAsync(PagedListParameters parameters);

        Task<IResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel);

        Task<LocationModel> SelectAsync(long locationId);
    }
}